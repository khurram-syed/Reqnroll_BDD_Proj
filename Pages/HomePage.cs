using MyReqnrollFirstProj.Helper;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MyReqnrollFirstProj.Pages;

public class HomePage : BasePage
{

    private By OtherPageHeading => By.TagName("h3");
    private By LinkText(string linkText) => By.LinkText(linkText);

    public HomePage(IWebDriver driver) : base(driver) { }

    public void OpneLink(string linkText)
    {
        _wait.GetVisibleElement(By.LinkText(linkText)).Click();
    }

    public void checkTitleAndHeading(string expectedTitle, string expectedHeading)
    {
        var actualTitle = _driver.Title;
        var actualHeading = _wait.GetVisibleElement(By.TagName("h1")).Text;
        Assert.That(actualTitle.Equals(expectedTitle), $"{actualTitle} : is not equal to : {expectedTitle}");
        Assert.That(actualHeading.Contains(expectedHeading), $"{actualHeading} : is not equal to : {expectedHeading}");
    }

    public void OpenAndNavigateToPage(string linkText, string expectedPageHeading)
    {
        ClickElement(LinkText(linkText),3);
        var actualPageHeading = _wait.GetVisibleElement(OtherPageHeading,3).Text;
        Assert.That(actualPageHeading.Contains(expectedPageHeading));
    }
}