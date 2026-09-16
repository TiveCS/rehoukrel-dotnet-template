using RehoukrelTemplate.Core.Domain.Model.Result;

namespace RehoukrelTemplate.Core.Application.Messaging.Abstracts;

public interface IRequestDispatcher
{
    Task<Result<TResponse>> Send<TRequest, TResponse>(
        TRequest request,
        CancellationToken ct)
        where TRequest : IRequest<TResponse>;
}