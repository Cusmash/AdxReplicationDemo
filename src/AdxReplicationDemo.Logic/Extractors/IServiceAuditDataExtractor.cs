using AdxReplicationDemo.Data.Views;

namespace AdxReplicationDemo.Logic.Extractors
{
    public interface IServiceAuditDataExtractor
    {
        Task<IReadOnlyList<ServiceAuditDataRow>> ExtractAsync(
            Guid? serviceId,
            CancellationToken cancellationToken = default);
    }
}
