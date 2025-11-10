using System;
using System.IO;
using AventStack.ExtentReports;
using MyReqnrollFirstProj.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;

namespace MyReqnrollFirstProj.Hooks;

[Binding]
public class Hooks
{
    private readonly DriverHelper _driverHelp;
    private readonly ScenarioContext _scenarioContext;
    private readonly ExtentTest _scenario;

    public Hooks(DriverHelper driverHelper, ScenarioContext scenarioContext)
    {
        _driverHelp = driverHelper;
        _scenarioContext = scenarioContext;
        _scenario = ExtentManager.Instance.CreateTest(scenarioContext.ScenarioInfo.Title);
        _scenarioContext["url"] = "https://the-internet.herokuapp.com/";
    }

    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        _ = ExtentManager.Instance;  // initialize report
    }

    [BeforeScenario("@ui")]
    public void BeforeScenario()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        _driverHelp.Driver = new ChromeDriver(options);
    }

    [AfterStep]
    public void AfterStep()
    {
        var stepInfo = _scenarioContext.StepContext.StepInfo.Text;
        _scenario.Log(Status.Info, $"Step : {stepInfo}");
    }

    [AfterScenario("@ui")]
    public void AfterScenario()
    {
        if (_scenarioContext.TestError != null)
        {
            var projectRoot = AppContext.BaseDirectory.Split("bin")[0];
            var screenshotDir = Path.Combine(projectRoot, "Reports", "Screenshots");
            Directory.CreateDirectory(screenshotDir);

            var screenshot = ((ITakesScreenshot)_driverHelp.Driver).GetScreenshot();
            
            var screenshotPath = Path.Combine(screenshotDir, $"{Guid.NewGuid()}.png");
            File.WriteAllBytes(screenshotPath, screenshot.AsByteArray);

            // Relative path for report to resolve as it doesn't resolve full path.
            var relativePath = Path.GetRelativePath(Path.Combine(projectRoot, "Reports"), screenshotPath);
            _scenario.Fail(_scenarioContext.TestError.Message)
                     .AddScreenCaptureFromPath(relativePath);
        }
        else
        {
            _scenario.Pass("✅ - Scenario passed successfully");
        }

        _driverHelp.Driver?.Quit();
        _driverHelp.Driver?.Dispose();
        // Writing the scenario in the HTML report
        ExtentManager.Instance.Flush();
        Console.WriteLine(" ✅  =============== AFTER SCENARIO - After Flush  ==========");
    }
}
