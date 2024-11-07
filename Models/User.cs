using System;
using System.Collections.Generic;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Gravatar { get; set; } = null!;

    public int Views { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
