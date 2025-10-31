namespace Domain.Models;

public partial class Like
{
    public int UserId { get; set; }

    public string TargetType { get; set; } = null!;

    public int TargetId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
