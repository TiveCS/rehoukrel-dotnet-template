using RehoukrelTemplate.Core.Domain.Model.Result;

namespace RehoukrelTemplate.Core.Application.Messaging.Abstracts;

public interface IRequestHandler<in TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
{
    Task<Result<TResponse>> Handle(TRequest request, CancellationToken ct);
}