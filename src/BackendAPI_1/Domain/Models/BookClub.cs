namespace Domain.Models;

public partial class BookClub
{
    public int ClubId { get; set; }

    public string Name { get; set; } = null!;

    public int CreatorId { get; set; }

    public virtual ICollection<ClubMember> ClubMembers { get; set; } = new List<ClubMember>();

    public virtual User Creator { get; set; } = null!;
}
