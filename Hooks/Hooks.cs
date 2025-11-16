using System;
using System.IO;
using AventStack.ExtentReports;
using MyReqnrollFirstProj.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using Reqnroll;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

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
        var browserName = Environment.GetEnvironmentVariable("BROWSER") ?? "chrome";
        _driverHelp.Driver = getWebDriver(browserName);
    }

    [AfterStep]
    public void AfterStep()
    {
        var stepInfo = _scenarioContext.StepContext.StepInfo.Text;
        _scenario.Log(Status.Info, $"Step : {stepInfo}");
    }

    [AfterScenario]
    public void AfterScenarioAPI()
    {
        if (_scenarioContext.TestError == null)
        {
            _scenario.Pass("✅ - Scenario passed successfully in non-@ui ");
            DisposingAndFlushingReport();
        }

       
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
            DisposingAndFlushingReport();
        }
    }

    private void DisposingAndFlushingReport()
    {
        // Disposing off the Driver
        _driverHelp.Driver?.Quit();
        _driverHelp.Driver?.Dispose();

        // Writing the scenario in the HTML report
        ExtentManager.Instance.Flush();
        Console.WriteLine(" ✅  =============== AFTER SCENARIO - Flush to Report  ==========");
    }

    public IWebDriver getWebDriver(string browserName)
    {
        IWebDriver driver;
        switch (browserName.ToLower())
        {
            case "chrome":
                new DriverManager().SetUpDriver(new ChromeConfig());
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--start-maximized");
                driver = new ChromeDriver(chromeOptions);
                break;
            case "firefox":
                new DriverManager().SetUpDriver(new FirefoxConfig());
                var firefoxOptions = new FirefoxOptions();
                firefoxOptions.AddArgument("--width=1920");
                firefoxOptions.AddArgument("--height=1080");
                driver = new FirefoxDriver(firefoxOptions);
                break;
            case "edge":
                new DriverManager().SetUpDriver(new EdgeConfig());
                var edgOptions = new EdgeOptions();
                edgOptions.AddArgument("--start-maximized");
                driver = new EdgeDriver(edgOptions);
                break;
            case "safari":
                driver = new SafariDriver();
                break;
            default:
                throw new ArgumentException($"Unsupported browser: {browserName}");

        }
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        return driver;
    }
}
