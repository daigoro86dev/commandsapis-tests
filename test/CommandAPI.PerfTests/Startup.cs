using CommandAPI.PerfTests.HttpClients;
using CommandAPI.PerfTests.Scenarios;
using CommandAPI.PerfTests.Steps;
using Microsoft.Extensions.DependencyInjection;

namespace CommandAPI.PerfTests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IHttpClientFixture, HttpClientFixture>();
            services.AddScoped<ICommandsStepsFixture, CommandsStepsFixture>();
            services.AddScoped<IScenarioFixture, ScenarioFixture>();
            services.AddScoped<ICommandsScenarioFixture, CommandsScenarioFixture>();
            services.AddScoped<ICommandsScenarioFixture, CommandsScenarioFixture>();
        }
    }
}