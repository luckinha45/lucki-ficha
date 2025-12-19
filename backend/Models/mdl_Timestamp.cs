namespace backend.Models;
public interface TimeStampEntity
{
    DateTime CreatedAt { get; set; }
    DateTime UpdatedAt { get; set; }
}