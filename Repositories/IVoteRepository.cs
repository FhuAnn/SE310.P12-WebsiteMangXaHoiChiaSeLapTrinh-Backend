using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Get;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories
{
    public interface IVoteRepository
    {
        Task<Vote> VotePost(Vote vote);
        Task<VoteDetail> GetVoteDetails(Guid postId,Guid userId);
    }
}
