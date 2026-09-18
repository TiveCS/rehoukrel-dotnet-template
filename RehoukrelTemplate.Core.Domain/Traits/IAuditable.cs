namespace RehoukrelTemplate.Core.Domain.Traits;

public interface IAuditable
{
    DateTimeOffset CreatedAt { get; set; }
    
    DateTimeOffset? UpdatedAt { get; set; }
}