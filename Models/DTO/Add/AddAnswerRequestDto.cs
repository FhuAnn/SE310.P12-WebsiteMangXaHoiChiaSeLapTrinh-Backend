﻿using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Add
{
    public class AddAnswerRequestDto
    {
        [Required]
        public string Body { get; set; } = null!;
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        public Guid? UserId { get; set; }

        [Required]
        public Guid? PostId { get; set; }
        public int Upvote { get; set; } = 0;
        public int Downvote { get; set; } = 0;

    }
}