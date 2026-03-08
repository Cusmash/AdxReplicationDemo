using AdxReplicationDemo.Contracts.Abstractions;
using AdxReplicationDemo.Contracts.Requests;
using AdxReplicationDemo.Contracts.Results;
using AdxReplicationDemo.Data.Abstractions;
using AdxReplicationDemo.Logic.Bootstrap;

var builder = WebApplication.CreateBuilder(args);

IBootstrapper bootstrapper = new Bootstrapper();
bootstrapper.Bootstrap(builder.Services, builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => Results.Ok("AdxReplicationDemo is running"));

app.MapPost("/data/get-service-audit-data", async (
    GetServiceAuditDataRequest request,
    IProcessor<GetServiceAuditDataRequest, IReadOnlyList<ServiceAuditDataResult>> processor,
    CancellationToken cancellationToken) =>
{
    var result = await processor.ProcessAsync(request, cancellationToken);
    return Results.Ok(result);
})
.WithName("GetServiceAuditData");

app.MapGet("/odata/service-audit-data", async (
    Guid? serviceId,
    IServiceAuditDataReader reader,
    CancellationToken cancellationToken) =>
{
    var rows = await reader.GetAsync(serviceId, cancellationToken);
    return Results.Ok(rows);
})
.WithName("QueryServiceAuditData");

app.Run();