using AdxReplicationDemo.Data.Views;

namespace AdxReplicationDemo.Data.Abstractions
{
    public interface IServiceAuditDataReader
    {
        Task<IReadOnlyList<ServiceAuditDataRow>> GetAsync(
            Guid? serviceId,
            CancellationToken cancellationToken = default);
    }
}
