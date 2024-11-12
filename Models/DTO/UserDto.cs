namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Username { get; set; } = null!;

        public string Gravatar { get; set; } = null!;

        public int Views { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        

    }
}
