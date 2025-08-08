using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using CapitolisTestAutomationUI.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using Reqnroll.BoDi;
using System.Security.Policy;
using System.Security.Cryptography;
using CapitolisTestAutomationUI.Support;

namespace CapitolisTestAutomationUI.Hooks
{
    [Binding]
    public class Hooks 
    {
        private readonly IObjectContainer _container;
        private IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        private static ExtentReports _extentReport;

        public Hooks(IObjectContainer container, ScenarioContext scenarioContext)
        {
            _container = container;
            _scenarioContext= scenarioContext;
        }

        [BeforeTestRun]
        public static void InitReport()
        {
            _extentReport = ExtentManager.CreateInstance();
        }


        [BeforeScenario]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _container.RegisterInstanceAs<IWebDriver>(_driver);
            _container.RegisterTypeAs<CreateAccountPage, CreateAccountPage>();
            _scenarioContext["test"] = _extentReport.CreateTest(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void LogStep()
        {
            var test = (ExtentTest)_scenarioContext["test"];
            if (_scenarioContext.TestError == null) 
                test.Pass(_scenarioContext.StepContext.StepInfo.Text);
            else
            {
                var shot = ((ITakesScreenshot)_driver).GetScreenshot();
                var file = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".png");
                shot.SaveAsFile(file);
                test.Fail(_scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(file).Build());
            }
        }

        [AfterScenario]
        public void Teardown()
        {
            _driver?.Quit();
        }

        [AfterTestRun]
        public static void FlushReport()
        {
            _extentReport.Flush();
        }

    }
}
