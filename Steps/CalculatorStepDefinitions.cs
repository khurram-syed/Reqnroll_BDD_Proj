using System;
using NUnit.Framework;
using Reqnroll;

namespace MyReqnrollFirstProj.Steps;

[Binding]
public sealed class CalculatorStepDefinitions
{
    // For additional details on Reqnroll step definitions see https://go.reqnroll.net/doc-stepdef

    int firstNumber = 0;
    int secondNumber = 0;

    [Given("the first number is {int}")]
    public void GivenTheFirstNumberIs(int number)
    {
        //TODO: implement arrange (precondition) logic
        // For storing and retrieving scenario-specific data see https://go.reqnroll.net/doc-sharingdata
        // To use the multiline text or the table argument of the scenario,
        // additional string/DataTable parameters can be defined on the step definition
        // method. 
        // dr = new ChromeDriver();
        // //https://the-internet.herokuapp.com/
        // dr.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
        // Thread.Sleep(5000);
        // dr.FindElement(By.LinkText("Form Authentication")).Click();
        // Thread.Sleep(5000);
        // dr.FindElement(By.Id("username")).Clear();
        // dr.FindElement(By.Id("username")).SendKeys("tomsmith");
        // dr.FindElement(By.Id("password")).Clear();
        // dr.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
        // dr.FindElement(By.TagName("button")).Click();
        // Thread.Sleep(5000);
        // var flashBanner = dr.FindElement(By.Id("flash")).Text;
        // Assert.That(flashBanner.Contains("You logged into a secure area!"));

       
       
        firstNumber = number;
        Console.WriteLine($"FirstNumber is : {firstNumber}");

    }

    [Given("the second number is {int}")]
    public void GivenTheSecondNumberIs(int number)
    {
        secondNumber = number;
        Console.WriteLine($"Second Number is : {secondNumber}");
    }

    [When("the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    {
        int result = firstNumber + secondNumber;
        Console.WriteLine($"Actual Result Number is : {result}");
    }

    [Then("the result should be {int}")]
    public void ThenTheResultShouldBe(int result)
    {
        int actualResult = firstNumber + secondNumber;
        Assert.That(result.Equals(actualResult));
        Console.WriteLine($"Expected Number is : {result}");
        //dr.Quit();
    }
   
}
