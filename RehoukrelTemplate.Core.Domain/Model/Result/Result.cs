using RehoukrelTemplate.Core.Application.Messaging;
using RehoukrelTemplate.Core.Domain.Model.Data;

namespace RehoukrelTemplate.Core.Domain.Model.Result;

public class Result
{
    public bool IsOk => Errors.Count == 0;

    public bool IsFail => !IsOk;
    
    public IReadOnlyList<DomainError> Errors { get; }

    protected Result(IEnumerable<DomainError> errors) => Errors = errors.ToList();

    public static Result Ok() => new([]);
    public static Result<T> Ok<T>(T value) => new(value);
    
    public static FailureResult Fail(DomainError error, params DomainError[] otherErrors) => new([error, ..otherErrors]);

    public static FailureResult Fail(IEnumerable<DomainError> errors) => new(errors.ToList());

    public static implicit operator Result(FailureResult failureResult) => new(failureResult.Errors);
    
    public static implicit operator Result(DomainError error) => new([error]);

    public static implicit operator Result(Unit unit) => Ok();
}

public class Result<T> : Result
{
    private readonly T? _value;
    
    public T Value => IsOk 
        ? _value ?? default! 
        : throw new InvalidOperationException("Cannot access value of a failed result.");
    
    public Result(IEnumerable<DomainError> errors) : base(errors)
    {
        _value = default!;
    }

    public Result(T value) : base([])
    {
        _value = value;
    }
    
    public static implicit operator Result<T>(T value) => new(value);
    
    public static implicit operator Result<T>(FailureResult failureResult) => new(failureResult.Errors);
    
    public static implicit operator Result<T>(DomainError error) => new([error]);
}