using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;


namespace CapitolisTestAutomationUI.Support
{
    public static class ExtentManager
    {
        public static ExtentReports CreateInstance()
        {
            var reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ExtentReport.html");
            var spark = new ExtentSparkReporter(reportPath);
            spark.Config.DocumentTitle = "Automation Test Report - Amazon Create New Account";
            spark.Config.ReportName = "Create New Account Flow";

            var extent = new ExtentReports();
            extent.AttachReporter(spark);
            extent.AddSystemInfo("Senior QA Engineer", "Gabriel Capotosti");
            extent.AddSystemInfo("Environment:", AppSettingsReader.GetConfigValue("environment"));
            extent.AddSystemInfo("Browser", AppSettingsReader.GetConfigValue("browser"));
            extent.AddSystemInfo("URL", AppSettingsReader.GetConfigValue("url"));

            return extent;
        }
    }
}
