using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

public partial class Post
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Title { get; set; } = null!;

    public string Tryandexpecting { get; set; } = null!;

    public int Views { get; set; }

    public DateTime CreatedAt { get; set; }= DateTime.Now;

    public DateTime UpdatedAt { get; set; }=DateTime.Now;

    public Guid? UserId { get; set; }

    public int Upvote { get; set; }

    public int Downvote { get; set; }

    public string Detailproblem { get; set; } = null!;

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    [NotMapped]    
    public List<string>? ImageUrls { get; set; } = new List<string>();

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();
    public virtual ICollection<Posttag> Posttags { get; set; } = new List<Posttag>();

    public virtual User? User { get; set; }
}
