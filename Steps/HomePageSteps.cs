using System.Threading;
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
    private HomePage HomePage;
    private AddRemoveElementPage AddRemoveElementPage;
    

    public HomePageSteps(IReqnrollOutputHelper outputHelper, DriverHelper driverHelper)
    {
        _driver = driverHelper.Driver;
        HomePage = new HomePage(_driver);
        AddRemoveElementPage = new AddRemoveElementPage(_driver);
    }

    [Given("I have navigated to home page")]
    public void GivenIHaveNavigatedToHomePage()
    {
        _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
        Thread.Sleep(2000);
    }

    [When("I check title {string} and heading {string}")]
    public void WhenICheckTitleAndHeading(string title, string heading)
    {
        expectedTitle = title;
        expectedHeading = heading;
    }

    [Then("I should see them exactly the same")]
    public void ThenIShouldSeeThemExactlyTheSame_()
    {
        var actualTitle = _driver.Title;
        var actualHeading = _driver.FindElement(By.TagName("h1")).Text;
        Assert.That(actualTitle.Equals(expectedTitle));
        Assert.That(actualHeading.Contains(expectedHeading));
        // }
        // Then I should see the "Add Element" button
        // When I click on "Add Element" button
        // Then I should see the "Delete" button

    }

    [When("I navigated to the page {string} by clicking the link {string}")]
    public void WhenINavigatedToThePageByClickingTheLink(string expectedHeading, string linkText)
    {
        HomePage.OpenAndNavigateToPage(linkText, expectedHeading);
    }

    [Then("I should see the button with text {string}")]
    public void ThenIShouldSeeTheButton(string btnText)
    {
        HomePage.CheckElementDisplayedByText(btnText);
    }

    [When("I click on {string} button")]
    public void WhenIClickOnXButton(string elementText)
    {
        HomePage.ClickElementByText(elementText);
    }

    [Then("I should see the {string} element")]
    [Then("I should see the {string} button")]
    public void ThenIShouldSeeTheXButton(string btnText)
    {
        AddRemoveElementPage.CheckElementDisplayedByText(btnText);
    }
}
