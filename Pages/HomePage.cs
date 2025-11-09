using System.Security.Cryptography;
using MyReqnrollFirstProj.Helper;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MyReqnrollFirstProj.Pages;

public class HomePage
{
    public readonly IWebDriver _driver;
    public HomePage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void OpneLink(string linkText)
    {
        _driver.FindElement(By.LinkText(linkText)).Click();
    }
    public void checkTitleAndHeading(string expectedTitle, string expectedHeading)
    {
        var actualTitle = _driver.Title;
        var actualHeading = _driver.FindElement(By.TagName("h1")).Text;
        Assert.That(actualTitle.Equals(expectedTitle));
        Assert.That(actualHeading.Contains(expectedHeading));
    }
}