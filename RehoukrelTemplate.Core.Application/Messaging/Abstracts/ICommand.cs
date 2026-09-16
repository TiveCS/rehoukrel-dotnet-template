namespace RehoukrelTemplate.Core.Application.Messaging.Abstracts;

public interface ICommand<TResponse> : IRequest<TResponse>
{
}

public interface ICommand : ICommand<Unit>
{
    
}