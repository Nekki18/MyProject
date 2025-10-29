using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class UsersBook
{
    public int UserId { get; set; }

    public int BookId { get; set; }

    public string? Status { get; set; }

    public int? CurrentPage { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
