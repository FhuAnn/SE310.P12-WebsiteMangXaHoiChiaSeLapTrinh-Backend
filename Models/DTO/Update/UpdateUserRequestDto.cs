namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Update
{
    public class UpdateUserRequestDto
    {
        public string Username { get; set; } = null!;

        public string Gravatar { get; set; } = "default";

        public string Email { get; set; } = null!;
    }
}
