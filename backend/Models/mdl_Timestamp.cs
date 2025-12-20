namespace backend.Models;
public abstract class TimeStampEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}