using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using System.Numerics;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories
{
    public interface IReportRepository
    {
        Task<IEnumerable<User>> getUsersInToday();
        Task<IEnumerable<User>> getUsersIn1YearAgo();
        Task<IEnumerable<User>> getUsersIn30DaysAgo();
        Task<IEnumerable<Post>> getPostsInToday();
        Task<IEnumerable<Post>> getPostsIn30DaysAgo();
        Task<IEnumerable<Post>> getPostIn1YearAgo();
        Task<IEnumerable<Answer>> getAnswersIn1YearAgo();
        Task<IEnumerable<Answer>> getAnswersIn30DaysAgo();
        Task<IEnumerable<Answer>> getAnwsersInToday();
    }
}
