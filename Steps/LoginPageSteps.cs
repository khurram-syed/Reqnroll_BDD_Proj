
using System.ComponentModel;
using MyReqnrollFirstProj.Helper;
using MyReqnrollFirstProj.Pages;
using OpenQA.Selenium;
using Reqnroll;

namespace MyReqnrollFirstProj.Steps;

[Binding]
public class LoginPageSteps
{

    private readonly IWebDriver _driver;
    private readonly LoginPage _loginPage;

    public LoginPageSteps(DriverHelper driverHelper)
    {
        _driver = driverHelper.Driver;
        _loginPage = new LoginPage(_driver);
    }


   [When("I enter following login details")]
    public void WhenINavigatedToThePageByClickingTheLink(DataTable dataTable)
    {
        // Creating Set of LoginCredentials table using ValueTuple
        var loginCreds = dataTable.CreateSet<(string username, string password)>();
        foreach(var cred in loginCreds)
        {
            _loginPage.EnterLoginCredentials(cred.username, cred.password);
        }

    }

    [Then("I should see the login success message {string}")]
    public void ThenIShouldSeeTheButton(string expectedSuccssMessage)
    {
        _loginPage.VerifySuccessfulLogin(expectedSuccssMessage);
    }



}