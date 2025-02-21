namespace API.Shared.Domain.Interfaces.Entity
{
    public interface IAuditable : ICreatedAtAuditable
    {
        DateTime UpdatedAt { get; set; }
    }
}
