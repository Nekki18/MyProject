namespace Domain.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int UserId { get; set; }

    public int BookId { get; set; }

    public short? Rating { get; set; }

    public string? Content { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual User User { get; set; } = null!;
}
