using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories
{
    public interface IAnswerRepository
    {
        Task<List<Answer>> GetAllAsync();
        Task<Answer> GetByIdAsync(Guid id);
        Task<Answer> CreateAsync(Answer answer);
        Task<Answer> UpdateAsync(Guid id, Answer answer);
        Task<Answer> DeleteAsync(Guid id);
    }
}
