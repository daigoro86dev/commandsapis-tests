using CommandAPI.PerfTests.Steps;
using NBomber.Contracts;

namespace CommandAPI.PerfTests.Scenarios
{
    public class CommandsScenarioFixture : ScenarioFixture, ICommandsScenarioFixture
    {
        private readonly ICommandsStepsFixture _stepsFixture;

        public CommandsScenarioFixture(ICommandsStepsFixture stepsFixture)
        {
            _stepsFixture = stepsFixture;
        }

        public Scenario GetAllCommandsScenario()
            => this.SetupScenario("Get All Commands Scenario", _stepsFixture.GetAllCommands());

        public Scenario GetCommandByIdScenario()
            => this.SetupScenario("Get Command By Id Scenario", _stepsFixture.GetCommandById(1));

    }
}