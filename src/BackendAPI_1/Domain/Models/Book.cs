namespace Domain.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string? Description { get; set; }

    public string? Genre { get; set; }

    public virtual ICollection<BookRecommendation> BookRecommendations { get; set; } = new List<BookRecommendation>();

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<UsersBook> UsersBooks { get; set; } = new List<UsersBook>();
}
