namespace Domain.Models;

public partial class Note
{
    public int NoteId { get; set; }

    public int UserId { get; set; }

    public int BookId { get; set; }

    public int? Page { get; set; }

    public string Content { get; set; } = null!;

    public bool IsPublic { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
