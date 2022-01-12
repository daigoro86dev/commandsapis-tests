using NBomber.Contracts;

namespace CommandAPI.PerfTests.Steps
{
    public interface ICommandsStepsFixture
    {
        IStep GetAllCommands();
        IStep GetCommandById(int id);
    }
}