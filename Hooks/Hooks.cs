using MyReqnrollFirstProj.Helper;
using OpenQA.Selenium.Chrome;
using Reqnroll;

namespace MyReqnrollFirstProj.Hooks;

[Binding]
public class Hooks
{
    private readonly DriverHelper _driverHelp;

    public Hooks(DriverHelper driverHelper)
    {
        _driverHelp = driverHelper;
    }

    [BeforeScenario("@ui")]
    public void BeforeScenario()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        _driverHelp.Driver = new ChromeDriver(options);
    }

    [AfterScenario("@ui")]
    public void AfterScenario()
    {
        _driverHelp.Driver?.Quit();
        _driverHelp.Driver?.Dispose();
    }

}