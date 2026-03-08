using System.Data;

namespace AdxReplicationDemo.Data.Abstractions
{
    public interface ISqlConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
