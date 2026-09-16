using System.Collections.Concurrent;
using Microsoft.Extensions.DependencyInjection;
using RehoukrelTemplate.Core.Application.Messaging.Abstracts;
using RehoukrelTemplate.Core.Application.Messaging.Delegates;
using RehoukrelTemplate.Core.Domain.Model.Result;

namespace RehoukrelTemplate.Core.Application.Messaging;

public class RequestDispatcher(IServiceProvider serviceProvider) : IRequestDispatcher
{
    public async Task<Result<TResponse>> Send<TRequest, TResponse>(
        TRequest request,
        CancellationToken ct)
        where TRequest : IRequest<TResponse>
    {
        var handler =
            serviceProvider.GetRequiredService<
                IRequestHandler<TRequest, TResponse>>();

        RequestHandlerDelegate<TResponse> next =
            () => handler.Handle(request, ct);

        var behaviors = serviceProvider
            .GetServices<IPipelineBehavior<TRequest, TResponse>>()
            .Reverse();

        foreach (var behavior in behaviors)
        {
            var currentNext = next;

            next = () => behavior.Handle(
                request,
                currentNext,
                ct);
        }

        return await next();
    }
}