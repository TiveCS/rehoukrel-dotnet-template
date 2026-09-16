using RehoukrelTemplate.Core.Domain.Model.Data;

namespace RehoukrelTemplate.Core.Domain.Model.Result;

public readonly struct FailureResult
{
    public List<DomainError> Errors { get; } = [];

    public FailureResult(List<DomainError> errors)
    {
        Errors = errors;
    }
    
    public static implicit operator FailureResult(List<DomainError> errors) => new(errors.ToList());
    
    public static implicit operator FailureResult(DomainError error) => new([error]);
}