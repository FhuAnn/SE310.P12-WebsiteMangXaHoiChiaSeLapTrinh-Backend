using System;
using System.Collections.Generic;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;

public partial class Post
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Body { get; set; } = null!;

    public int Views { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid? UserId { get; set; }

    public int Upvote { get; set; }

    public int Downvote { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Posttag> Posttags { get; set; } = new List<Posttag>();

    public virtual User? User { get; set; }
}
