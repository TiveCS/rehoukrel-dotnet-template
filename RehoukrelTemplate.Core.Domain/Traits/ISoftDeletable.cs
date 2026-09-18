namespace RehoukrelTemplate.Core.Domain.Traits;

public interface ISoftDeletable
{
    DateTimeOffset? DeletedAt { get; set; }
}