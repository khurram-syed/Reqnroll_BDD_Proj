
**PROJECT CONFIGURATION :**
    
    - The Porject has been developed With following C# Reqnroll  dependencies/tools
      1- <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.8.0" />
      2- <PackageReference Include="Reqnroll" Version="3.2.1" />
      3- <PackageReference Include="Reqnroll.NUnit" Version="3.2.1" />
      4- <PackageReference Include="nunit" Version="4.0.1" />
      5- <PackageReference Include="NUnit3TestAdapter" Version="4.5.0" />
      6- <PackageReference Include="FluentAssertions" Version="6.12.0" />
      7- <PackageReference Include="Selenium.WebDriver" Version="4.38.0" />
      8- <PackageReference Include="Selenium.Support" Version="4.38.0" />
      9- <PackageReference Include="DotNetSeleniumExtras.WaitHelpers" Version="3.11.0" />
      10- <PackageReference Include="ExtentReports" Version="5.0.4" />


RUN OPTIONS:

1- It can be run either from commandline or IDE accordingly. 

 
 (i) Tests can be run with following commandline Maven command
 
   > dotnet build
   > dotnet test
 
  or
   
   > dotnet test --filter "Category=scenario2"  
  
 *Note#1:* Chrome Driver for Windows & Mac has been provided at src/main/resources/drivers but please check the compatibility 
       with your Chrome browser version accordingly.
 
 *Note#2:* You can also run in Firefox by changing "driverName" to "Firefox" in src/main/java/com/cardetailcheck/driver/SeleniumDriver.java file  
       
**REPORTING** :   

 - Extent HTML Reports will be generated automatically at following location with above command execution. 
  Screenshots will get embedded in the reports too for the Failing tests.
 
     > Report Location : <root>/Reports/TestReport_DateTime.Now:yyyyMMdd_HHmmss.html
 
  
**Scenario EXPLAINATION**:

TASK : There are Three Feature files .
 
Explanation: BDD style(Feature files implementation) has been followed for more readability along with POM(Page Object Model) 
            design pattern. 
  
  - Feature Files : "SearchCarDetails.feature" has been implemented the above scenario at following location
      > Features/Calculator.feature
      > Features/HomePage.feature
      > Features/LoginPage.feature
  
  - Step Definition : Feature file implementation is located at following location along with hooks
     >  Steps/CalculatorStepDefinitions.cs
     >  Steps/HomePageSteps.cs
     >  Steps/LoginPageSteps.cs

  - Hooks  : This got following hooks
      > [BeforeTestRun] : Initialising Report
      > [BeforeScenario("@ui")] : To Initialze Driver
      > [AfterScenario] : To add each step in the Extent Report
      > [AfterScenario("@ui")] : To Capture the screenshot for failed step or add success step info to ExtentReport 
  - POM (Page Object Model) Files : They have been implemented through Page Object Model. All the Page Objects are located at 
     >  Pages/AddRemoveElementPage.cs
     >  Pages/Basepage.cs
     >  Pages/HomePage.cs
     >  Pages/LoginPage.cs
  

  - Test Fail/Pass Status : While Running through command line you'll see number of failures clear description in "Then" step
   on console along with after following "AssertionError" description. For example
