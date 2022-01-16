using System;
using CommandAPI.PerfTests.Scenarios;
using FluentAssertions;
using NBomber.CSharp;
using Xunit;

namespace CommandAPI.PerfTests.Tests
{
    [Trait("Category", "Performance")]
    public class CommandTests
    {
        private readonly ICommandsScenarioFixture _scenarioFixture;

        public CommandTests(ICommandsScenarioFixture scenarioFixture)
        {
            _scenarioFixture = scenarioFixture;
        }

        [Theory]
        [InlineData(15, 5)]
        public void CommandsTest(int rps, int timeSpan)
        {
            var getAllCommandsScenario = _scenarioFixture.GetAllCommandsScenario()
                .WithoutWarmUp()
                .WithLoadSimulations(new[]
                {
                    Simulation.InjectPerSec(rate: rps, during: TimeSpan.FromSeconds(timeSpan))
                });

            var getCommandByIdScenario = _scenarioFixture.GetCommandByIdScenario()
                .WithoutWarmUp()
                .WithLoadSimulations(new[]
                {
                    Simulation.InjectPerSec(rate: rps, during: TimeSpan.FromSeconds(timeSpan))
                });

            var nodeStats = NBomberRunner.RegisterScenarios(getAllCommandsScenario, getCommandByIdScenario)
                .Run();

            var stepStats = nodeStats.ScenarioStats;

            foreach (var productScenario in stepStats)
            {
                productScenario.StepStats[0].Ok.Request.Count.Should().Be(rps * timeSpan);
            }
        }
    }
}