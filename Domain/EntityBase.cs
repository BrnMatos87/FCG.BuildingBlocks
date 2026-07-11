using FCG.BuildingBlocks.Enums;

namespace FCG.BuildingBlocks.Domain
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();

        public DateTime CreatedAt { get; protected set; }

        public DateTime? UpdatedAt { get; protected set; }

        public StatusType Status { get; protected set; } = StatusType.Active;

        public virtual void Activate()
        {
            if (Status == StatusType.Active)
                return;

            Status = StatusType.Active;
            UpdatedAt = DateTime.UtcNow;
        }

        public virtual void Inactivate()
        {
            if (Status == StatusType.Inactive)
                return;

            Status = StatusType.Inactive;
            UpdatedAt = DateTime.UtcNow;
        }

        public bool IsActive()
        {
            return Status == StatusType.Active;
        }
    }
}
