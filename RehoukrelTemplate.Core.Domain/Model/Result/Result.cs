using RehoukrelTemplate.Core.Domain.Model.Data;

namespace RehoukrelTemplate.Core.Domain.Model.Result;

public class Result
{
    public bool IsOk => Errors.Count == 0;

    public bool IsFail => !IsOk;
    
    public IReadOnlyList<DomainError> Errors { get; private set; }

    protected Result(IEnumerable<DomainError> errors) => Errors = errors.ToList();

    public static Result Ok() => new([]);
    
    public static Result Fail(params DomainError[] errors) => new(errors);
}