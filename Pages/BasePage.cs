using MyReqnrollFirstProj.Helper;
using OpenQA.Selenium;

namespace MyReqnrollFirstProj.Pages;

public class BasePage
{
    protected readonly IWebDriver _driver;
    protected readonly WaitHelper _wait;

    private By SubPageHeading => By.TagName("h3");

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
}