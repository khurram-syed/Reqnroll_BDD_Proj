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
    }
   
}
