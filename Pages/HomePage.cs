using MyReqnrollFirstProj.Helper;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MyReqnrollFirstProj.Pages;

public class HomePage : BasePage
{

    private By OtherPageHeadingH3 => By.TagName("h3");
    private By OtherPageHeadingH2 => By.TagName("h2");
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
        ClickElement(LinkText(linkText), 3);
        By locator = expectedPageHeading.Contains("Login") ? OtherPageHeadingH2 : OtherPageHeadingH3;

        var actualPageHeading = GetText(locator);
        Assert.That(actualPageHeading.Contains(expectedPageHeading));
    }
}