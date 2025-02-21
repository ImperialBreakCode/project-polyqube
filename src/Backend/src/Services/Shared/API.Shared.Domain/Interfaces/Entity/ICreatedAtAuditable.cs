namespace API.Shared.Domain.Interfaces.Entity
{
    public interface ICreatedAtAuditable
    {
        DateTime CreatedAt { get; }

        DateTime SetCreatedAtTimestamp();
    }
}
