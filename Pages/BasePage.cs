using MyReqnrollFirstProj.Helper;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MyReqnrollFirstProj.Pages;

public class BasePage
{
    protected readonly IWebDriver _driver;
    protected readonly WaitHelper _wait;
    protected By LinkText(string linkText) => By.LinkText(linkText);
    protected By OtherPageHeadingH3 => By.TagName("h3");
    protected By OtherPageHeadingH2 => By.TagName("h2");


    public BasePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WaitHelper(driver);
    }

    public void ClickElement(By locator, int waitTime = 2) =>
        _wait.GetVisibleElement(locator, waitTime).Click();

    public void EnterText(By locator, string text, int waitTime = 2)
    {
        var element = _wait.GetVisibleElement(locator, waitTime);
        element.Clear();
        element.SendKeys(text);
    }

    public string GetText(By locator, int waitTime = 2)
    {
        return _wait.GetVisibleElement(locator, waitTime).Text;
    }

    public bool CheckElementDisplayed(By locator)
    {
        return _wait.GetVisibleElement(locator).Displayed;
    }

    public bool CheckElementDisplayedByText(string elementText)
    {
        By locator = By.XPath("//*[.='" + elementText + "']");
        return _wait.GetVisibleElement(locator).Displayed;
    }

    public void ClickElementByText(string elementText)
    {
        By locator = By.XPath("//*[.='" + elementText + "']");
        _wait.GetVisibleElement(locator).Click();
    }

    public void ClickLinkByText(string elementText)
    {
        By locator = By.XPath("//a[.='" + elementText + "']");
        _wait.GetVisibleElement(locator).Click();
    }

    public void ClickElementByLocator(By locator)
    {
        _wait.GetVisibleElement(locator).Click();
    }

    public void OpneLink(string linkText)
    {
        _wait.GetVisibleElement(By.LinkText(linkText)).Click();
    }

    public void OpenLinkToPage(string linkText, string expectedPageHeading)
    {
        ClickElement(LinkText(linkText), 3);
        By locator = expectedPageHeading.Contains("Login") ? OtherPageHeadingH2 : OtherPageHeadingH3;

        var actualPageHeading = GetText(locator);
        Assert.That(actualPageHeading.Contains(expectedPageHeading));
    }

}