using OpenQA.Selenium;
using MyReqnrollFirstProj.Helper;
using NUnit.Framework;

namespace MyReqnrollFirstProj.Pages;

public class AddRemoveElementPage : BasePage
{

    public AddRemoveElementPage(IWebDriver driver):base(driver){}

    private By AddElementBtn => By.CssSelector("div.example > button");
    private By DeleteBtn => By.CssSelector("div#elements > button");


    public void ClickOnAddElementBtn()
    {
        ClickElement(AddElementBtn);
    }

    public void CheckDelementBtnIsVisible()
    {
        Assert.That(CheckElementDisplayed(DeleteBtn));
    }



}