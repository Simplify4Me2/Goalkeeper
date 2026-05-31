namespace Goalkeeper.Server.Application.Interfaces;

public interface ICommandHandler<in TCommand>
{
    Task HandleAsync(TCommand command, CancellationToken cancellationToken);
}
