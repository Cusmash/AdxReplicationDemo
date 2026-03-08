using AdxReplicationDemo.Contracts.Abstractions;
using AdxReplicationDemo.Contracts.Requests;
using AdxReplicationDemo.Contracts.Results;
using AdxReplicationDemo.Data.Abstractions;
using AdxReplicationDemo.Data.Repositories;
using AdxReplicationDemo.Data.Sql;
using AdxReplicationDemo.Logic.Processors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AdxReplicationDemo.Logic.Extractors;

namespace AdxReplicationDemo.Logic.Bootstrap
{
    public sealed class Bootstrapper : IBootstrapper
    {
        public void Bootstrap(IServiceCollection services, IConfiguration configuration)
        {
            this.RegisterData(services, configuration);
            this.RegisterExtractors(services);
            this.RegisterProcessors(services);
        }

        private void RegisterData(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSettings>(
                configuration.GetSection(DatabaseSettings.SectionName));

            services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();
            services.AddScoped<IServiceAuditDataReader, ServiceAuditDataReader>();
        }

        private void RegisterExtractors(IServiceCollection services)
        {
            services.AddScoped<IServiceAuditDataExtractor, ServiceAuditDataExtractor>();
        }

        private void RegisterProcessors(IServiceCollection services)
        {
            services.AddScoped<
                IProcessor<GetServiceAuditDataRequest, IReadOnlyList<ServiceAuditDataResult>>,
                GetServiceAuditDataProcessor>();
        }
    }
}
