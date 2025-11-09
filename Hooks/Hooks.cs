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

        // options.AddUserProfilePreference("profile.password_manager_enabled", false);
        // options.AddUserProfilePreference("credentials_enable_service", false);
        // options.AddUserProfilePreference("autofill.profile_enabled", false);
        // options.AddUserProfilePreference("autofill.credit_card_enabled", false);
        // options.AddUserProfilePreference("autofill.password_manager_enabled", false);
        // options.AddArgument("--disable-notifications");
        // options.AddArgument("--disable-save-password-bubble");
        // options.AddArgument("--password-store=basic");
        _driverHelp.Driver = new ChromeDriver(options);
    }

    [AfterScenario("@ui")]
    public void AfterScenario()
    {
        _driverHelp.Driver?.Quit();
        _driverHelp.Driver?.Dispose();
    }

}