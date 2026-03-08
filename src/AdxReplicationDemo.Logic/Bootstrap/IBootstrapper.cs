using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdxReplicationDemo.Logic.Bootstrap
{
    public interface IBootstrapper
    {
        void Bootstrap(IServiceCollection services, IConfiguration configuration);
    }
}
