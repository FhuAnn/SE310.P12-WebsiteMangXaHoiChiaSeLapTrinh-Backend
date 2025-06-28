using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Username { get; set; } = null!;

        public string Gravatar { get; set; } = "default";

        public int Views { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public string Email { get; set; } = null!;

        public virtual ICollection<AnswerDto> Answers { get; set; } = new List<AnswerDto>();

        public virtual ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();

        public virtual ICollection<PostDto> Posts { get; set; } = new List<PostDto>();

        public virtual ICollection<UserRoleDto> UserRoles { get; set; } = new List<UserRoleDto>();

        public virtual ICollection<WatchedTag> WatchedTags { get; set; } = new List<WatchedTag>();

        public virtual ICollection<IgnoredTag> IgnoredTags { get; set; } = new List<IgnoredTag>();
    }
}
