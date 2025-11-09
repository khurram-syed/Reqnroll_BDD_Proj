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
    private readonly IReqnrollOutputHelper _outputHelper;
    private readonly IWebDriver _driver;
    private string expectedTitle, expectedHeading;
    private HomePage HomePage;
    
        public HomePageSteps(IReqnrollOutputHelper outputHelper, DriverHelper driverHelper)
        {
            _outputHelper = outputHelper;
            _driver = driverHelper.Driver;
            HomePage = new HomePage(_driver);
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
        }
}
