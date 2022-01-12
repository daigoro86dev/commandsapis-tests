using NBomber.Contracts;
using NBomber.CSharp;

namespace CommandAPI.PerfTests.Scenarios
{
    public class ScenarioFixture : IScenarioFixture
    {
        public Scenario SetupScenario(string name, params IStep[] steps)
        {
            return ScenarioBuilder.CreateScenario(name, steps);
        }
    }
}