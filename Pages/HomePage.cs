using MyReqnrollFirstProj.Helper;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MyReqnrollFirstProj.Pages;

public class HomePage : BasePage
{

    public HomePage(IWebDriver driver) : base(driver) { }

   
    public void OpenHomePage(string url)
    {
        _driver.Navigate().GoToUrl(url);
    }

    public void checkTitleAndHeading(string expectedTitle, string expectedHeading)
    {
        var actualTitle = _driver.Title;
        var actualHeading = _wait.GetVisibleElement(By.TagName("h1")).Text;
        Assert.That(actualTitle.Equals(expectedTitle), $"{actualTitle} : is not equal to : {expectedTitle}");
        Assert.That(actualHeading.Contains(expectedHeading), $"{actualHeading} : is not equal to : {expectedHeading}");
    }

}