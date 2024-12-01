using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using System;
using System.Collections.Generic;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

public partial class Tag
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Tagname { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public virtual ICollection<Posttag> Posttags { get; set; } = new List<Posttag>();

    public virtual ICollection<WatchedTag> WatchedByUsers { get; set; } = new List<WatchedTag>();
  
    // Liên kết ngược với bảng IgnoredTag
    public virtual ICollection<IgnoredTag> IgnoredByUsers { get; set; } = new List<IgnoredTag>();
}
