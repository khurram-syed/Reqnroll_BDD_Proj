using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MyReqnrollFirstProj.Helper;

public class WaitHelper
{
    private readonly IWebDriver _driver;

    public WaitHelper(IWebDriver driver)
    {
        _driver = driver;
    }
    public IWebElement GetVisibleElement( By locator, int waitTime = 2)
    {
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitTime));
        return wait.Until(ExpectedConditions.ElementIsVisible(locator));

    }
}