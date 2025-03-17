namespace API.Shared.Domain.Interfaces.Entity
{
    public interface ISoftDeletable
    {
        DateTime? DeletedAt { get; }

        void SoftDelete();
        void UndoSoftDelete();
    }
}
