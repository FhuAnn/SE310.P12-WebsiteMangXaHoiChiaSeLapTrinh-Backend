using System;
using System.Collections.Generic;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;

public partial class Answer
{
    public Guid Id { get; set; }

    public string Body { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid? UserId { get; set; }

    public Guid? PostId { get; set; }

    public int Upvote { get; set; }

    public int Downvote { get; set; }

    public virtual Post? Post { get; set; }

    public virtual User? User { get; set; }
}
