namespace Domain.Models;

public partial class BookRecommendation
{
    public int RecommendationId { get; set; }

    public int UserId { get; set; }

    public int ReceiverId { get; set; }

    public int BookId { get; set; }

    public string? Message { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual User Receiver { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
