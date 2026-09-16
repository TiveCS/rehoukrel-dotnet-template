using RehoukrelTemplate.Core.Application.Messaging.Abstracts;
using RehoukrelTemplate.Core.Application.Messaging.Delegates;
using RehoukrelTemplate.Core.Domain.Model.Result;

namespace RehoukrelTemplate.Core.Application.Messaging.Behaviors;

public class LoggingBehavior<TRequest, TResponse>() : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<Result<TResponse>> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken ct)
    {
        Console.WriteLine("LoggingBehavior: Handling request of type {0}", typeof(TRequest).Name);
        
        var result = await next();

        Console.WriteLine("LoggingBehavior: Finished handling request of type {0}", typeof(TRequest).Name);

        return result;
    }
}