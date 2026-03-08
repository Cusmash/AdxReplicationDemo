using AdxReplicationDemo.Contracts.Abstractions;
using AdxReplicationDemo.Contracts.Requests;
using AdxReplicationDemo.Contracts.Results;
using AdxReplicationDemo.Logic.Extractors;

namespace AdxReplicationDemo.Logic.Processors
{
    public sealed class GetServiceAuditDataProcessor
    : IProcessor<GetServiceAuditDataRequest, IReadOnlyList<ServiceAuditDataResult>>
    {
        private readonly IServiceAuditDataExtractor serviceAuditDataExtractor;

        public GetServiceAuditDataProcessor(IServiceAuditDataExtractor serviceAuditDataExtractor)
        {
            this.serviceAuditDataExtractor = serviceAuditDataExtractor;
        }

        public async Task<IReadOnlyList<ServiceAuditDataResult>> ProcessAsync(
            GetServiceAuditDataRequest request,
            CancellationToken cancellationToken = default)
        {
            var rows = await this.serviceAuditDataExtractor.ExtractAsync(
                request.ServiceId,
                cancellationToken);

            var results = rows
                .Select(row => new ServiceAuditDataResult
                {
                    ServiceId = row.ServiceId,
                    ServiceName = row.ServiceName,
                    ServiceType = row.ServiceType,
                    Region = row.Region,
                    Owner = row.Owner,
                    IsActive = row.IsActive,
                    RenewalStatus = row.RenewalStatus,
                    ServiceCreatedAt = row.ServiceCreatedAt,
                    AuditId = row.AuditId,
                    AuditDate = row.AuditDate,
                    ComplianceStatus = row.ComplianceStatus,
                    FindingsCount = row.FindingsCount,
                    RiskLevel = row.RiskLevel,
                    AuditComments = row.AuditComments,
                    AuditCreatedAt = row.AuditCreatedAt
                })
                .ToList();

            return results;
        }
    }
}
