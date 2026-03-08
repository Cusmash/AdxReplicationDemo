
namespace AdxReplicationDemo.Contracts.Abstractions
{
    public interface IProcessor<in TRequest, TResult>
        where TRequest : IRequest<TResult>
    {
        Task<TResult> ProcessAsync(TRequest request, CancellationToken cancellationToken = default);
    }
}
