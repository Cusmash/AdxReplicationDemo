using AdxReplicationDemo.Data.Abstractions;
using AdxReplicationDemo.Data.Views;

namespace AdxReplicationDemo.Logic.Extractors
{
    public sealed class ServiceAuditDataExtractor : IServiceAuditDataExtractor
    {
        private readonly IServiceAuditDataReader serviceAuditDataReader;

        public ServiceAuditDataExtractor(IServiceAuditDataReader serviceAuditDataReader)
        {
            this.serviceAuditDataReader = serviceAuditDataReader;
        }

        public async Task<IReadOnlyList<ServiceAuditDataRow>> ExtractAsync(
            Guid? serviceId,
            CancellationToken cancellationToken = default)
        {
            return await this.serviceAuditDataReader.GetAsync(serviceId, cancellationToken);
        }
    }
}
