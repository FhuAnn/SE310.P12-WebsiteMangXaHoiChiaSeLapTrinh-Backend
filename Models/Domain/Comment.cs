using System;
using System.Collections.Generic;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

public partial class Comment
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Body { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public Guid? UserId { get; set; }

    public int EntityType { get; set; }

    public Guid EntityId { get; set; }

    public virtual Post? Post { get; set; }
    public virtual Answer? Answer { get; set; }
    public virtual User? User { get; set; }
}
