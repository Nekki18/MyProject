namespace Domain.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<BookClub> BookClubs { get; set; } = new List<BookClub>();

    public virtual ICollection<BookRecommendation> BookRecommendationReceivers { get; set; } = new List<BookRecommendation>();

    public virtual ICollection<BookRecommendation> BookRecommendationUsers { get; set; } = new List<BookRecommendation>();

    public virtual ICollection<ClubMember> ClubMembers { get; set; } = new List<ClubMember>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<UsersBook> UsersBooks { get; set; } = new List<UsersBook>();
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Middlename { get; set; }
    public object Birthdate { get; set; }
    public string Login { get; set; }
    public string Id { get; set; }
}
