using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

public partial class Image
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string FileExtension { get; set; } = null!;

    [NotMapped]
    public IFormFile file { get; set; }
    public long FileSizeInBytes { get; set; }

    public string FilePath { get; set; } = null!;

    public Guid? PostId { get; set; }

    public Guid? UserId { get; set; }

    public virtual Post? Post { get; set; }

    public virtual User? User { get; set; }
}
