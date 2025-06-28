﻿using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Get
{
    public class HomePostDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string DetailProblem { get; set; } = null!;

        public string TryAndExpecting { get; set; } = null!;

        public int Views { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid? UserId { get; set; }
        public int Upvote { get; set; }
        public int Downvote { get; set; }
        public bool isDeleted { get; set; }
        public int noOfReports { get; set; }
        public virtual HomeUserDto User { get; set; } = null!;
        public virtual ICollection<HomePostTagDto> Posttags { get; set; } = new List<HomePostTagDto>();
        public virtual ICollection<HomeAnswerDto> Answers { get; set; } = new List<HomeAnswerDto>();
    }
}
