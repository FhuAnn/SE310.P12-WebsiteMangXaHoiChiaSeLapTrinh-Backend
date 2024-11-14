namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO
{
    public class LoginResponseDto
    {
        public Guid UserId { get; set; } 
        public string JwtToken { get; set; }
    }
}
