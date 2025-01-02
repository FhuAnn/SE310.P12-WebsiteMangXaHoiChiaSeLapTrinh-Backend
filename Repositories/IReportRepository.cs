using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Get;
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
        Task<bool> createReport(Report report);
        Task<List<Report>> getReportsFromPost(Guid postId);
        Task<IEnumerable<Report>> getAllReportsInAYear_unfinish();
        Task<IEnumerable<Report>> getAllReportsIn30Days_unfinish();
        Task<IEnumerable<Report>> getAllReportsInADayBefore_unfinish();
        Task<IEnumerable<Report>> getAllReportsInAYear_finish();
        Task<IEnumerable<Report>> getAllReportsIn30Days_finish();
        Task<IEnumerable<Report>> getAllReportsInADayBefore_finish();
    }
}
