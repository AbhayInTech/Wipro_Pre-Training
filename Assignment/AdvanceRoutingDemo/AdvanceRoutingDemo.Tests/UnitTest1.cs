using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace AdvanceRoutingDemo.Tests;

public class UnitTest1 : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public UnitTest1(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task TestComplexRoute_Products()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/Products/Electronics/1");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task TestComplexRoute_Users()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/Users/john/Orders");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task TestGuidConstraint_Invalid()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/Product/invalid-guid");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task TestDynamicRouting_Admin()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/Home/Dashboard?role=Admin");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var content = await response.Content.ReadAsStringAsync();
        Assert.Contains("Admin Dashboard", content);
    }

    [Fact]
    public async Task TestDynamicRouting_User()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/Home/Dashboard?role=User");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var content = await response.Content.ReadAsStringAsync();
        Assert.Contains("User Dashboard", content);
    }
}
