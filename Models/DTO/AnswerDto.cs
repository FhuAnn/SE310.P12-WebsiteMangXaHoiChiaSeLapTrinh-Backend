﻿using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Get;
using System.Text.Json.Serialization;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO
{
    public class AnswerDto
    {
        public Guid Id { get; set; }

        public string Body { get; set; } = null!;

        public DateTime CreatedAt { get; set; } 

        public DateTime UpdatedAt { get; set; }

        public Guid? UserId { get; set; }

        public Guid? PostId { get; set; }
        public int Upvote { get; set; }
        public int Downvote { get; set; }
        public ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();

        public virtual AnswerPostDto? Post { get; set; }

    }
}
