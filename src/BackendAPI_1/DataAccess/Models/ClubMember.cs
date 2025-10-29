using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class ClubMember
{
    public int ClubId { get; set; }

    public int UserId { get; set; }

    public string? Role { get; set; }

    public DateTime? JoinedAt { get; set; }

    public bool? IsApproved { get; set; }

    public virtual BookClub Club { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
