using CommandAPI.PerfTests.HttpClients;
using NBomber.Contracts;
using NBomber.CSharp;
using CommandAppClient.Clients;

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
                var response = await ApiClients.GetCommands();

                return response.IsSuccessful ?
                    Response.Ok(statusCode: (int)response.StatusCode, sizeBytes: 1024)
                    : Response.Fail(statusCode: (int)response.StatusCode, sizeBytes: 1024);
            });
        }

        public IStep GetCommandById(int id)
        {
            return Step.Create("Get Command By Id", async context =>
            {
                var response = await ApiClients.GetCommandById(id);

                return response.IsSuccessful ?
                    Response.Ok(statusCode: (int)response.StatusCode, sizeBytes: 1024)
                    : Response.Fail(statusCode: (int)response.StatusCode, sizeBytes: 1024);
            });
        }
    }
}