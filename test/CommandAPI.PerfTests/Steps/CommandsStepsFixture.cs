using CommandAPI.PerfTests.HttpClients;
using NBomber.Contracts;
using NBomber.CSharp;

namespace CommandAPI.PerfTests.Steps
{
    public class CommandsStepsFixture : ICommandsStepsFixture
    {
        private readonly IHttpClientFixture _httpClient;

        public CommandsStepsFixture(IHttpClientFixture httpClient)
        {
            _httpClient = httpClient;
        }

        public IStep GetAllCommands()
        {
            return Step.Create("Get All Commands", async context =>
            {
                var response =
                    await _httpClient.SetClient().GetAsync("/api/commands", context.CancellationToken);

                return _httpClient.GetResponseStatusCode(response);
            });
        }

        public IStep GetCommandById(int id)
        {
            return Step.Create("Get Command By Id", async context =>
            {
                var response =
                    await _httpClient.SetClient().GetAsync($"/api/commands/{id}", context.CancellationToken);

                return _httpClient.GetResponseStatusCode(response);
            });
        }
    }
}