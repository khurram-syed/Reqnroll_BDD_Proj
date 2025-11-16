using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MyReqnrollFirstProj.Helper;
using MyReqnrollFirstProj.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using Reqnroll;

namespace MyReqnrollFirstProj.Steps;

[Binding]
public class ApiSteps
{
    private ScenarioContext _scenarioContext;
    private APIClientHelper _apiClient;
    private HttpResponseMessage _response;


    public ApiSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _apiClient = new APIClientHelper();
    }

    [When("I send a GET request to {string} endpoint")]
    public async Task WhenISendAGETRequestTo(string endpoint)
    {
        _response = await _apiClient.GetAsync(endpoint);
    }

    [Then("I should see response status {int} for GET")]
    public async Task ThenIShouldSeeResponseStatusForGET(int statusCode)
    {

        Assert.That((int)_response.StatusCode, Is.EqualTo(statusCode));
        var text = await _response.Content.ReadAsStringAsync();
        var postObjs = JsonConvert.DeserializeObject<List<Post>>(text);
        _scenarioContext["postObjs"] = postObjs;

        //Logging the other values
        Console.WriteLine(_response.StatusCode);
        Console.WriteLine($"Title : {postObjs[0].Title}");
        Console.WriteLine($"Id : {postObjs[0].Id}");
        Console.WriteLine($"Count : {postObjs.Count}");
    }

    [When("I send a POST request to {string} endpoint with following values")]
    public async Task WhenISendAPOSTRequestToWithFollowingValues(string endpoint, DataTable dataTable)
    {
        var records = dataTable.CreateSet<(string Title, string Body)> ().ToArray();
        var post = new Post()
        {
            UserId = 1,
            Id = 1,
            Title = records[0].Title,
            Body = records[0].Body
        };
        _response = await _apiClient.PostAsync<Post>(endpoint, post);
        Console.WriteLine($"Status : {(int)_response.StatusCode}");
        Assert.That((int)_response.StatusCode, Is.EqualTo(201));
    }
        
    [Then("the response status should be {int}")]
    public void ThenTheResponseStatusShouldBe(int statusCode)
    {
        Console.WriteLine($"Actual Status Code: {(int)_response.StatusCode} - Expected : {statusCode}");
        Assert.That((int)_response.StatusCode, Is.EqualTo(statusCode));
    }

    [Then("the response should contain the title {string}")]
    public async Task ThenTheResponseShouldContainTheTitle(string title)
    {
        var text = await _response.Content.ReadAsStringAsync();
        var post = JsonConvert.DeserializeObject<Post>(text);
        Console.WriteLine($"Actual Title {post.Title} --  Expected title {title}");
        Assert.That(post.Title, Is.EqualTo(title),
                            $"Actual Title {post.Title} is mismatching with Expected title {title}");
    }

    [Then("I should see response status {int}")]
    public async Task ThenIShouldSeeResponseStatus(int statusCode)
    {
        Console.WriteLine($"Actual STatus : {(int)_response.StatusCode} - Expected Status : {statusCode}");
        Assert.That((int)_response.StatusCode, Is.EqualTo(statusCode),
                   $"Actual STatus : {(int)_response.StatusCode} NOT Matched with Expected Status : {statusCode}");
        var text = await _response.Content.ReadAsStringAsync();
        var post = JsonConvert.DeserializeObject<Post>(text);
        Console.WriteLine($" Post Title : {post.Title}");
        Console.WriteLine($" Post Id : {post.Id}");
    }

    [When("I send a PUT request to {string} endpoint with title {string}")]
    public async Task WhenISendAGETRequestTo(string endpoint, string updatedTitle)
    {
        int id = int.Parse(endpoint.Split("/")[1]);
        var post = new Post()
        {
            Id = id,
            UserId = id,
            Title = updatedTitle,
            Body = "Updated body"
        };

        _response = await _apiClient.PutAsync(endpoint, post);
        Console.WriteLine($"Actual StatusCode: {_response.StatusCode}");
    }

    [When("I send a DELETE request to {string} endpoint")]
    public async Task WhenISendADELETERequestTo(string endpoint)
    {
        _response = await _apiClient.DeleteAsync(endpoint);
    }

}