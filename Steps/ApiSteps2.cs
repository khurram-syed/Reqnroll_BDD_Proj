using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using MyReqnrollFirstProj.Helper;
using MyReqnrollFirstProj.Models;
using NUnit.Framework;
using Reqnroll;

namespace MyReqnrollFirstProj.Steps;

[Binding]
public class ApiSteps2
{
    private ScenarioContext _scenarioContext;
    private APIClientHelper _apiClient;
    private HttpResponseMessage _response;


    public ApiSteps2(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _apiClient = new APIClientHelper();
    }

    [Then("I should see the following records with corresponding values")]
    public void ThenIShouldSeeResponseStatus(DataTable table)
    {
        // Getting the postObjs from ApiStep1.cs using scenarioContext
        var posts = (List<Post>)_scenarioContext["postObjs"];
       
       // Just for logging purposes
        Console.WriteLine($"Body : {posts[0].Title}");
        Console.WriteLine($"Id : {posts[0].Id}");
        Console.WriteLine($"Count : {posts.Count}");
        
        
        var tableRows = table.CreateSet<ApiRecord>().ToList();
        foreach(var row in tableRows)
        {
            int index = row.RecordNo - 1;
            if (index >= posts.Count)
            {
              Assert.That(posts[index].Id, Is.EqualTo(row.Id),
               $"❌ Mismatch in Id for record #{index}");
              Assert.That(posts[index].UserId, Is.EqualTo(row.UserId),
               $"❌ Mismatch in UserId for record #{index}");
            }
            
        }
    }

   
}