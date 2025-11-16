using MyReqnrollFirstProj.Helper;
using MyReqnrollFirstProj.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace MyReqnrollFirstProj.Steps;

[Binding]
public class HomePageSteps 
{
    private readonly IWebDriver _driver;
    private string expectedTitle, expectedHeading;
    private HomePage _homePage;
    private BasePage _basePage;
    private AddRemoveElementPage AddRemoveElementPage;
    private LoginPage _loginPage;
    private ScenarioContext _scenarioContext;
        

    public HomePageSteps(ScenarioContext scenarioContext, DriverHelper driverHelper)
    {
        _driver = driverHelper.Driver;
        _basePage = new BasePage(_driver);
        _homePage = new HomePage(_driver);
        _loginPage = new LoginPage(_driver);
        _scenarioContext = scenarioContext;
        AddRemoveElementPage = new AddRemoveElementPage(_driver);
    }

    [Given("I have navigated to home page")]
    public void GivenIHaveNavigatedToHomePage()
    {
        _homePage.OpenHomePage(_scenarioContext["url"].ToString());
    }

    [When("I check title {string} and heading {string}")]
    public void WhenICheckTitleAndHeading(string title, string heading)
    {
        expectedTitle = title;
        expectedHeading = heading;
    }

    [Then("I should see them exactly the same as mentioned above")]
    public void ThenIShouldSeeThemExactlyTheSame_()
    {
        var actualTitle = _driver.Title;
        var actualHeading = _driver.FindElement(By.TagName("h1")).Text;
        Assert.That(actualTitle.Equals(expectedTitle));
        Assert.That(actualHeading.Equals(expectedHeading));
    }

    [When("I navigated to the page {string} by clicking the link {string}")]
    public void WhenINavigatedToThePageByClickingTheLink(string expectedHeading, string linkText)
    {
        _homePage.OpenLinkToPage(linkText, expectedHeading);
    }

    [Then("I should see the button with text {string}")]
    public void ThenIShouldSeeTheButton(string btnText)
    {
        _basePage.CheckElementDisplayedByText(btnText);
    }

    [When("I click on {string} button")]
    public void WhenIClickOnXButton(string elementText)
    {
        if (elementText.Contains("Logout"))
        {
            _loginPage.ClickLogout();
        }
        else
        {
            _homePage.ClickElementByText(elementText);
        }
    }

    [Then("I should see the {string} element")]
    [Then("I should see the {string} button")]
    public void ThenIShouldSeeTheXButton(string btnText)
    {
        AddRemoveElementPage.CheckElementDisplayedByText(btnText);
    }
}
