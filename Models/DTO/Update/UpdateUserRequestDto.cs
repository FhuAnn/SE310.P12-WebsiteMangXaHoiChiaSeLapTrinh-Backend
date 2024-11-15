namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Update
{
    public class UpdateUserRequestDto
    {
        public string Username { get; set; } = null!;


        public DateTime UpdatedAt { get; set; }

        public string Email { get; set; } = null!;
    }
}
