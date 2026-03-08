using System.Data;
using AdxReplicationDemo.Data.Abstractions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace AdxReplicationDemo.Data.Sql
{
    public sealed class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly DatabaseSettings databaseSettings;

        public SqlConnectionFactory(IOptions<DatabaseSettings> databaseSettings)
        {
            this.databaseSettings = databaseSettings.Value;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(this.databaseSettings.ConnectionString);
        }
    }
}
