using System.Threading;
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
    private By LogoutLocator => By.CssSelector("a > i");


    public void EnterLoginCredentials(string username, string password)
    {
        EnterText(UserNameInput, username);
        EnterText(PasswordInput, password);
        ClickElement(LoginBtn);
    }

    public void VerifySuccessfulLogin(string expectedSuccessText)
    {
        Thread.Sleep(3000);
        var actualSuccessText = GetText(FlashBanner, 5);
        Assert.That(actualSuccessText.Contains(expectedSuccessText),
                   $"{actualSuccessText} does not contain expected : {expectedSuccessText}");
    }

    public void ClickLogout()
    {
        ClickElementByLocator(LogoutLocator);
    }

}