namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Get
{
    public class HomePostTagDto
    {
        public Guid TagId { get; set; }
        public virtual PostDto Post { get; set; } = null!;
        public virtual TagDto Tag { get; set; } = null!;
    }
}
