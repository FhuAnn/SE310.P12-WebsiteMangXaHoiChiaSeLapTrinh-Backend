using System;
using System.Collections.Generic;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

public partial class Comment
{
    public Guid Id { get; set; }

    public string Body { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid? UserId { get; set; }

    public Guid? PostId { get; set; }

    public Guid? ParentId { get; set; }

    public int EntityType { get; set; }

    public Guid EntityId { get; set; }

    public virtual ICollection<Comment> InverseParent { get; set; } = new List<Comment>();

    public virtual Comment? Parent { get; set; }

    public virtual Post? Post { get; set; }

    public virtual User? User { get; set; }
}
