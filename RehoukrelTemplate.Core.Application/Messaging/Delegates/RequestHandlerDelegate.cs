using RehoukrelTemplate.Core.Domain.Model.Result;

namespace RehoukrelTemplate.Core.Application.Messaging.Delegates;

public delegate Task<Result<TResponse>> RequestHandlerDelegate<TResponse>();