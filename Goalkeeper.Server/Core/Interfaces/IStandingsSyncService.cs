namespace Goalkeeper.Server.Core.Interfaces;

public interface IStandingsSyncService
{
    Task RecalculateGroupAsync(string groupName, CancellationToken cancellationToken);
}
