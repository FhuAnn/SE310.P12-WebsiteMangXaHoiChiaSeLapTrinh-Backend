﻿using System;
using System.Collections.Generic;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

public partial class Posttag
{
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public Guid PostId { get; set; }

    public Guid TagId { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual Tag Tag { get; set; } = null!;
}
