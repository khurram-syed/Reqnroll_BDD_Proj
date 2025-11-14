
**PROJECT CONFIGURATION :**
    
    - The Porject has been developed With following C# Reqnroll  dependencies/tools
      1- Microsoft.NET.Test.Sdk" Version="17.8.0"
      2- "Reqnroll" Version="3.2.1"
      3- "Reqnroll.NUnit" Version="3.2.1"
      4- "nunit" Version="4.0.1"
      5- "NUnit3TestAdapter" Version="4.5.0"
      6- "FluentAssertions" Version="6.12.0"
      7- "Selenium.WebDriver" Version="4.38.0"
      8- "Selenium.Support" Version="4.38.0"
      9- "DotNetSeleniumExtras.WaitHelpers" Version="3.11.0"
      10- "ExtentReports" Version="5.0.4"
      11- "WebDriverManager" Version="2.17.6"


RUN OPTIONS:

1- It can be run either from commandline or IDE(VS Code or Visual Sutdio) accordingly. 

 
 (i) Tests can be run with following commandline Maven command
 
   > dotnet build

   > dotnet test
 
  or
   
   > dotnet test --filter "Category=scenario12"  
  
 **BROWSERS** :  
 *Note#:* All Drivers can be invoked by following command. By default it would run in Chrome

    > BROWWSER=firefox dotnet test --filter "Category=scenario12"  
 

       
**REPORTING** :   

 - Extent HTML Reports will be generated automatically at following location with above command execution. 
  Screenshots will get embedded in the reports too for the Failing tests.
 
     > Report Location : <root>/Reports/TestReport_DateTime.Now:yyyyMMdd_HHmmss.html
 
  
**Scenario EXPLAINATION**:

TASK : There are Three Feature files .
 
Explanation: BDD style(Feature files implementation) has been followed for more readability along with POM(Page Object Model) 
            design pattern. 
  
  - Feature Files : Following UI features has been implemented with the following location
      > Features/Calculator.feature.  ==> Non-UI test [Won't initiate ChromeDriver]

      > Features/HomePage.feature.  ==> UI HomePage Tests

      > Features/LoginPage.feature. ==> UI LoginPage Tests
  
  - Step Definition : Feature file implementation is located at following location along with hooks
     >  Steps/CalculatorStepDefinitions.cs. 

     >  Steps/HomePageSteps.cs

     >  Steps/LoginPageSteps.cs

  - Hooks  : This got following hooks
      > [BeforeTestRun] : Initialising Report

      > [BeforeScenario("@ui")] : To Initialze Driver

      > [AfterScenario] : To add each step in the Extent Report
      
      > [AfterScenario("@ui")] : To Capture the screenshot for failed step or add success step info to ExtentReport 
  
  - POM (Page Object Model) Files : They have been implemented through Page Object Model. All the Page Objects are located at 
     >  Pages/AddRemoveElementPage.cs
     
     > Pages/Basepage.cs
     
     > Pages/HomePage.cs
     
     > Pages/LoginPage.cs
   
 
 
   **API Tests**: 
  
   They are written to verify various HTTP Methods GET/POST/PUT/DELETE for the resource /posts against the baseURL : https://jsonplaceholder.typicode.com/
   -  API Tests and Corresponding Files: This has been implemented using HttpClient with NewtonSoft. Feature and Step definition files are
       >  Features/ApiTests.feature

       >  Steps/ApiSteps.cs
     
       >  Steps/ApiSteps2.cs
  
    
  -  API Models and APIClient Helper files are
     >  Helper/APIClientHelper.cs
     
     >  Models/ApiRecords.cs
     
     >  Post.cs
  


