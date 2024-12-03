namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Get
{
    public class AuthenUserDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Username { get; set; } = null!;

        public string Gravatar { get; set; } = "default";

        public int Views { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public string Email { get; set; } = null!;
    }
}
