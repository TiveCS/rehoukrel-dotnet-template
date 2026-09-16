using RehoukrelTemplate.Core.Domain.Model.Data;

namespace RehoukrelTemplate.Core.Domain.Errors;

public static class CommonErrors
{
    public static readonly DomainError NoPermission =
        new("Common.NoPermission", "You do not have permission to perform this action.", DomainErrorType.Forbidden);
}