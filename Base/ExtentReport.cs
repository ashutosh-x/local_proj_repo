using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Tracing;

namespace local_proj_repo.Base
{
    [Binding]
    class ExtentReport
    {
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;

        public static string featureNameReport;
        public static string scenarioNameReport;
        public static string htmlReportFinal;

        public static int StepIncrement = 1;

        [BeforeTestRun]
        public static void InitializeReport()
        {
            StandaloneExtentReport();
        }
        public static void StandaloneExtentReport()
        {
            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent;
            string htmlReport = dir.FullName + @"\TestResults\ExtentReport.html";
            string testResultFolder = dir.FullName + @"\TestResults";
            dir = new DirectoryInfo(testResultFolder);
            if (dir.Exists)
            {
                dir.Delete(true);
            }
            var htmlReporter = new ExtentHtmlReporter(htmlReport);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            htmlReporter.Config.DocumentTitle = "OrangeHRM";
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }
        [AfterTestRun]
        public static void TearDownReport()
        {
            /*BaseClass.Driver.Close();
            BaseClass.Driver.Dispose();*/
            extent.Flush();
        }
        [BeforeFeature]
        public static void BeforeFeature()
        {
            var featureNameTitle = FeatureContext.Current.FeatureInfo.Title;
            featureNameReport = featureNameTitle.ToString();
            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent;
            string htmlReport = dir.FullName + @"\TestResults\Screenshots" + "\\" + featureNameReport;
            Directory.CreateDirectory(htmlReport);
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }
        [BeforeScenario]
        public void BeforeScenario()
        {
            var currentScenarioTitle = ScenarioContext.Current.ScenarioInfo.Title;
            scenarioNameReport = currentScenarioTitle.ToString();
            scenarioNameReport = scenarioNameReport.Substring(0, 2);
            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent;
            htmlReportFinal = dir.FullName + @"\TestResults\Screenshots" + "\\" + featureNameReport + "\\" + scenarioNameReport;
            Directory.CreateDirectory(htmlReportFinal);
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }
        [AfterStep]
        public void InsertReportingSteps()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            var error = ScenarioContext.Current.TestError;
            PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            object TestResult = getter.Invoke(ScenarioContext.Current, null);

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
                else if (stepType == "And")
                {
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
            }

            if (TestResult.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
            }
            Thread.Sleep(500);
            TakeScreenshot(BaseClass.Driver);
        }
        public void TakeScreenshot(IWebDriver driver)
        {
            try
            {
                string fileNameBase = string.Format("error_{0}_{1}_{2}",
                    FeatureContext.Current.FeatureInfo.Title.ToIdentifier(),
                    ScenarioContext.Current.ScenarioInfo.Title.ToIdentifier(),
                    DateTime.Now.ToString("yyyyMMdd_HHmmss"));

                DirectoryInfo testDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + @"\TestResults").Parent.Parent;

                if (!testDirectory.Exists)
                {
                    testDirectory.Create();
                }

                ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;

                if (testDirectory != null)
                {
                    var screenshot = takesScreenshot.GetScreenshot();
                    string screenshotFilePath = htmlReportFinal;
                    screenshot.SaveAsFile(screenshotFilePath + "\\" + "Step " + StepIncrement + ".jpeg", ScreenshotImageFormat.Jpeg);
                    Console.WriteLine("Screenshot: {0}", new Uri(screenshotFilePath));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while taking screenshot: {0}", ex);
            }
            StepIncrement++;
        }
    }
}
