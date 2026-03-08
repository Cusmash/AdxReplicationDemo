using AdxReplicationDemo.Contracts.Abstractions;
using AdxReplicationDemo.Contracts.Results;

namespace AdxReplicationDemo.Contracts.Requests
{
    public sealed class GetServiceAuditDataRequest : IRequest<IReadOnlyList<ServiceAuditDataResult>>
    {
        public Guid? ServiceId { get; init; }
    }
}
