namespace RehoukrelTemplate.Core.Domain.Model.Data;

public record DomainError(string Code, string Message, DomainErrorType ErrorType);