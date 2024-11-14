using System;
using System.Collections.Generic;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

public partial class User
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Gravatar { get; set; } = "Default";

    public int Views { get; set; }

    public string Email { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public virtual ICollection<WatchedTag> WatchedTags { get; set; } = new List<WatchedTag>();
    public virtual ICollection<IgnoredTag> IgnoredTags { get; set; } = new List<IgnoredTag>();
}
