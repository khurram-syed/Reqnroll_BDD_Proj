using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions.Specialized;
using Newtonsoft.Json;

namespace MyReqnrollFirstProj.Helper;

public class APIClientHelper
{

    private readonly HttpClient _httpClient;

    public APIClientHelper()
    {
        _httpClient = new HttpClient()
        {
            BaseAddress = new System.Uri("https://jsonplaceholder.typicode.com/")
        };
    }

    public async Task<HttpResponseMessage> GetAsync(string endpoint)
    {
        return await _httpClient.GetAsync(endpoint);
    }

    public async Task<HttpResponseMessage> PostAsync<T>(string endpoint, T payload)
    {
        var json = JsonConvert.SerializeObject(payload);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        return await _httpClient.PostAsync(endpoint, content);
    }


    public async Task<HttpResponseMessage> PutAsync<T>(string endpoint, T payload)
    {
        var json = JsonConvert.SerializeObject(payload);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        return await _httpClient.PutAsync(endpoint, content);
    }

    public async Task<HttpResponseMessage> DeleteAsync(string endpoint)
    {
        return await _httpClient.DeleteAsync(endpoint);
    }
}