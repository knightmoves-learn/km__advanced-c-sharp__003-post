using System.Text;
using System.Text.Json;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

public class Test
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public Test(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    private string testContent = JsonSerializer.Serialize(new
    {
        name = "Test Testerson",
        jobTitle = "Software Developer",
        salary = 100000
    });

    [Theory]
    [InlineData("/Employee")]
    public async Task EmployeeApiReturnsSuccessfulHTTPResponseCodeOnGETAndNoLongerReturnsDefaultEmployee(string url)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync(url);

        string dfltEmployee = JsonSerializer.Serialize(new
        {
            name = "Default Employee",
            jobTitle = "Unemployed",
            salary = 0
        });

        Assert.True(response.IsSuccessStatusCode, $"EmployeeApi did not return successful HTTP Response Code on GET request; instead received {(int)response.StatusCode}: {response.StatusCode}");

        string responseContent = await response.Content.ReadAsStringAsync();
        Assert.True(!responseContent.Contains(dfltEmployee), $"EmployeeApi is still returning the default employee on GET request");

    }

    [Theory]
    [InlineData("/Employee")]
    public async Task EmployeeApiCanPOSTEmployeeReturnsEmployeeBeingAdded(string url)
    {
        var client = _factory.CreateClient();

        HttpRequestMessage sendRequest = new HttpRequestMessage(HttpMethod.Post, url);
        sendRequest.Content = new StringContent(testContent,
                                                Encoding.UTF8,
                                                "application/json");

        var response = await client.SendAsync(sendRequest);
        Assert.True(response.IsSuccessStatusCode, $"EmployeeApi did not return successful HTTP Response Code on POST request; instead received {(int)response.StatusCode}: {response.StatusCode}");

        string responseContent = await response.Content.ReadAsStringAsync();
        Assert.True(responseContent == testContent, $"EmployeeApi did not return the employee being added as a response from the POST request; \n Expected : {testContent} \n Received : {responseContent} \n");
    }

    [Theory]
    [InlineData("/Employee")]
    public async Task EmployeeApiReturnsEmployeeFromGETAfterBeingAddedThroughPost(string url)
    {
        var client = _factory.CreateClient();

        var getResponse = await client.GetAsync(url);
        Assert.True(getResponse.IsSuccessStatusCode, $"EmployeeApi did not return successful HTTP Response Code on GET request; instead received {(int)getResponse.StatusCode}: {getResponse.StatusCode}");

        string responseContent = await getResponse.Content.ReadAsStringAsync();
        Assert.True(responseContent == $"[{testContent}]", $"EmployeeApi did not return the added employees from a GET request; \n Expected : [{testContent}] \n Received : {responseContent}");

    }
}