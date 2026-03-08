using AdxReplicationDemo.Data.Abstractions;
using AdxReplicationDemo.Data.Views;
using Dapper;

namespace AdxReplicationDemo.Data.Repositories
{
    public sealed class ServiceAuditDataReader : IServiceAuditDataReader
    {
        private readonly ISqlConnectionFactory sqlConnectionFactory;

        public ServiceAuditDataReader(ISqlConnectionFactory sqlConnectionFactory)
        {
            this.sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IReadOnlyList<ServiceAuditDataRow>> GetAsync(
            Guid? serviceId,
            CancellationToken cancellationToken = default)
        {
            const string sql = """
            SELECT
                ServiceId,
                ServiceName,
                ServiceType,
                Region,
                Owner,
                IsActive,
                RenewalStatus,
                ServiceCreatedAt,
                AuditId,
                AuditDate,
                ComplianceStatus,
                FindingsCount,
                RiskLevel,
                AuditComments,
                AuditCreatedAt
            FROM dbo.vw_ServiceAuditData
            WHERE (@ServiceId IS NULL OR ServiceId = @ServiceId)
            ORDER BY ServiceId, AuditDate DESC
            """;

            using var connection = this.sqlConnectionFactory.CreateConnection();

            var command = new CommandDefinition(
                commandText: sql,
                parameters: new { ServiceId = serviceId },
                cancellationToken: cancellationToken);

            var rows = await connection.QueryAsync<ServiceAuditDataRow>(command);
            return rows.ToList();
        }
    }
}
