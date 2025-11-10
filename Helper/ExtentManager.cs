using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace MyReqnrollFirstProj.Helper
{
    public static class ExtentManager
    {
        private static readonly Lazy<ExtentReports> _lazy = new(() =>
        {
            //Creating the Reports folder
            var projectRoot = AppContext.BaseDirectory.Split("bin")[0];
            var reportsDir = Path.Combine(projectRoot, "Reports");
            Directory.CreateDirectory(reportsDir);

            //Creating HTML file with ExtentSparkReporter with path
            var htmlPath = Path.Combine(reportsDir, $"TestReport_{DateTime.Now:yyyyMMdd_HHmmss}.html");
            var htmlReporter = new ExtentSparkReporter(htmlPath);

            //Adding all the Meta Data.
            var extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Name", "Herokuapp Automation");
            extent.AddSystemInfo("Tester", "KASyed");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Framework", "Reqnroll + Selenium");

            htmlReporter.Config.DocumentTitle = "Reqnroll Automation Test Report";
            htmlReporter.Config.ReportName = "Reqnroll UI Test Results";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;

            return extent;
        });

        public static ExtentReports Instance => _lazy.Value;
    }
}
