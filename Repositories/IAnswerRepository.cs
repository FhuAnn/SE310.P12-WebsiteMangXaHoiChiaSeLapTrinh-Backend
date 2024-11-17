using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories.Implement;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories
{
    public interface IAnswerRepository:IStackOverflowRepository<Answer>
    {
        Task<List<Answer>> GetAnswerByUserIdAsync(Guid id);
    }
}
