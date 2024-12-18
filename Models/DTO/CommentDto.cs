﻿using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO
{
    public class CommentDto
    {
        public Guid Id { get; set; }

        public string Body { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid? UserId { get; set; }

        public Guid? PostId { get; set; }

        public virtual Post? Post { get; set; }

        public virtual User? User { get; set; }
    }
}
