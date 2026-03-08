
namespace AdxReplicationDemo.Data.Views
{
    public sealed class ServiceAuditDataRow
    {
        public Guid ServiceId { get; init; }
        public string ServiceName { get; init; } = string.Empty;
        public string ServiceType { get; init; } = string.Empty;
        public string Region { get; init; } = string.Empty;
        public string Owner { get; init; } = string.Empty;
        public bool IsActive { get; init; }
        public int RenewalStatus { get; init; }
        public DateTime ServiceCreatedAt { get; init; }
        public Guid? AuditId { get; init; }
        public DateTime? AuditDate { get; init; }
        public string? ComplianceStatus { get; init; }
        public int? FindingsCount { get; init; }
        public string? RiskLevel { get; init; }
        public string? AuditComments { get; init; }
        public DateTime? AuditCreatedAt { get; init; }
    }
}
