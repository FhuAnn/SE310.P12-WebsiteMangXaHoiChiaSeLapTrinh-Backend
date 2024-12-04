using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

public partial class Answer
{
    public Guid Id { get; set; }

    public string Body { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public Guid? UserId { get; set; }

    public Guid? PostId { get; set; }
    public int Upvote { get; set; }

    public int Downvote { get; set; }

    public virtual Post? Post { get; set; }

    public virtual User? User { get; set; }
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
