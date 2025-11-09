using NUnit.Framework;
using OpenQA.Selenium;

namespace MyReqnrollFirstProj.Pages;

public class LoginPage : BasePage
{
    public LoginPage(IWebDriver driver) : base(driver) { }

    private By UserNameInput => By.Id("username");
    private By PasswordInput => By.Id("password");
    private By LoginBtn => By.CssSelector("button[type='submit']");
    private By FlashBanner => By.Id("flash");


    public void EnterLoginCredentials(string username, string password)
    {
        EnterText(UserNameInput, username);
        EnterText(PasswordInput, password);
        ClickElement(LoginBtn);
    }

    public void VerifySuccessfulLogin(string expectedSuccessText)
    {
        var actualSuccessText = GetText(FlashBanner, 5);
        Assert.That(actualSuccessText.Contains(expectedSuccessText),
                   $"{actualSuccessText} does not contain expected : {expectedSuccessText}");
    }

}