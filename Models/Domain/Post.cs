using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

public partial class Post
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Tryandexpecting { get; set; } = null!;

    public int Views { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid? UserId { get; set; }

    public int Upvote { get; set; }

    public int Downvote { get; set; }

    public string Detailproblem { get; set; } = null!;

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();
    public virtual ICollection<Posttag> Posttags { get; set; } = new List<Posttag>();

    public virtual User? User { get; set; }
}
