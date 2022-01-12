using NBomber.Contracts;

namespace CommandAPI.PerfTests.Scenarios
{
    public interface IScenarioFixture
    {
        Scenario SetupScenario(string name, params IStep[] steps);
    }
}