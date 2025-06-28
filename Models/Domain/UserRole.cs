﻿using System;
using System.Collections.Generic;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

public partial class UserRole
{
    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }

    public DateTime AssignedAt { get; set; } = DateTime.Now;

    public virtual Role Role { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
