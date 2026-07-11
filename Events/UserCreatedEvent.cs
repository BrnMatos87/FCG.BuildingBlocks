namespace FCG.BuildingBlocks.Events;

public class UserCreatedEvent
{
    public Guid UserId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public Guid CorrelationId { get; set; }
}