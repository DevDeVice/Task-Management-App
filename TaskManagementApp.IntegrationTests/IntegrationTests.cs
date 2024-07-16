using Xunit;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using TaskManagementApp;

public class IntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
{
    private readonly HttpClient _client;

    public IntegrationTests(WebApplicationFactory<Startup> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async void GetTasks_ReturnsSuccessStatusCode()
    {
        // Act
        var response = await _client.GetAsync("/api/tasks");

        // Assert
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        Assert.Contains("Task", responseString);
    }
}
