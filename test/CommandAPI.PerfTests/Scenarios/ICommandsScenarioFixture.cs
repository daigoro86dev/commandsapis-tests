using NBomber.Contracts;

namespace CommandAPI.PerfTests.Scenarios
{
    public interface ICommandsScenarioFixture
    {
        Scenario GetAllCommandsScenario();
        Scenario GetCommandByIdScenario();
    }
}