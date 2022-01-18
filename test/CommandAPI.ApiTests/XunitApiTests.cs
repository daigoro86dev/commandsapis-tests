using System.Net;
using System.Threading.Tasks;
using CommandAppClient.Clients;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace CommandAPI.ApiTests;

[Trait("Category", "API")]
public class XunitApiTests
{
    private readonly ITestOutputHelper output;

    public XunitApiTests(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public async Task TestGetAllCommands()
    {
        var apiCommandsRes = await ApiClients.GetCommands();

        apiCommandsRes.StatusCode.Should().Be(HttpStatusCode.OK);
        apiCommandsRes.IsSuccessful.Should().Be(true);
        apiCommandsRes.Content.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task TestGetCommandById()
    {
        var apiCommandRes = await ApiClients.GetCommandById(1);

        apiCommandRes.StatusCode.Should().Be(HttpStatusCode.OK);
        apiCommandRes.IsSuccessful.Should().Be(true);
    }
}