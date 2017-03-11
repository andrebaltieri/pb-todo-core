namespace Todo.Domain.Commands
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}