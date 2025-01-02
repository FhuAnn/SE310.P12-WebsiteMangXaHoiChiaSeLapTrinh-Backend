using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Get;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories.Implement
{
    public class SQLReportRepository : IReportRepository
    {
        private readonly Stackoverflow1511Context context;

        public SQLReportRepository(Stackoverflow1511Context context) 
        {
            this.context = context;
        }

        public async Task<IEnumerable<Post>> getPostIn1YearAgo()
        {
            var oneYearAgo = DateTime.Now.AddYears(-1);
            var posts = await context.Posts.Where(p => p.CreatedAt >= oneYearAgo).ToListAsync();
            return posts;
        }

        public async Task<IEnumerable<Post>> getPostsIn30DaysAgo()
        {
            var thirdtyDayAgo = DateTime.Now.AddDays(-30);
            var posts = await context.Posts.Where(p => p.CreatedAt >= thirdtyDayAgo).ToListAsync();
            return posts;
        }

        public async Task<IEnumerable<Post>> getPostsInToday()
        {
            var posts = await context.Posts.Where(p => p.CreatedAt >= DateTime.Now).ToListAsync();
            return posts;
        }

        public async Task<IEnumerable<User>> getUsersIn1YearAgo()
        {
            var oneYearAgo = DateTime.Now.AddYears(-1);
            var users = await context.Users.Where(u=>u.CreatedAt>=oneYearAgo).ToListAsync();
            return users;
        }

        public async Task<IEnumerable<User>> getUsersIn30DaysAgo()
        {
            var thirdtyDaysAgo = DateTime.Now.AddDays(-30);
            var users = await context.Users.Where(u => u.CreatedAt >= thirdtyDaysAgo).ToListAsync();
            return users;
        }

        public async Task<IEnumerable<User>> getUsersInToday()
        {
            var dayAgo = DateTime.Now.AddDays(-1);
            var users = await context.Users.Where(u => u.CreatedAt >= dayAgo).ToListAsync();
            return users;
        }

        public async Task<IEnumerable<Answer>> getAnswersIn1YearAgo()
        {
            var oneYearAgo = DateTime.Now.AddMonths(-1);
            var answers = await context.Answers.Where(u => u.CreatedAt >= oneYearAgo).ToListAsync();
            return answers;
        }

        public async Task<IEnumerable<Answer>> getAnswersIn30DaysAgo()
        {
            var thirdtyDaysAgo = DateTime.Now.AddDays(-30);
            var answers = await context.Answers.Where(u => u.CreatedAt >= thirdtyDaysAgo).ToListAsync();
            return answers;
        }

        public async Task<IEnumerable<Answer>> getAnwsersInToday()
        {
            var dayAgo = DateTime.Now.AddDays(-1);
            var answers = await context.Answers.Where(u => u.CreatedAt >= dayAgo).ToListAsync();
            return answers;
        }

        public async Task<bool> createReport(Report report)
        {
            await context.Reports.AddAsync(report);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Report>> getReportsFromPost(Guid postId)
        {
            var reports = await context.Reports
                .Where(r=>r.PostId == postId)
                .ToListAsync();
            return reports;
        }

        public async Task<IEnumerable<Report>> getAllReportsInAYear_unfinish()
        {
            var oneYearAgo = DateTime.UtcNow.AddYears(-1);
            var result = await context.Reports
              .Where(r=>r.ReportedAt >= oneYearAgo && r.IsDeleted==false).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Report>> getAllReportsIn30Days_unfinish()
        {
            var oneThirdtyDays= DateTime.UtcNow.AddDays(-30);
            var result = await context.Reports
              .Where(r => r.ReportedAt >= oneThirdtyDays && r.IsDeleted == false).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Report>> getAllReportsInADayBefore_unfinish()
        {
            var oneDayAgo = DateTime.UtcNow.AddDays(-1);
            var result = await context.Reports
              .Where(r => r.ReportedAt >= oneDayAgo && r.IsDeleted == false).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Report>> getAllReportsInAYear_finished()
        {
            var oneYearAgo = DateTime.UtcNow.AddYears(-1);
            var result = await context.Reports
              .Where(r => r.ReportedAt >= oneYearAgo && r.IsDeleted == true).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Report>> getAllReportsIn30Days_finished()
        {
            var oneThirdtyDays = DateTime.UtcNow.AddDays(-30);
            var result = await context.Reports
              .Where(r => r.ReportedAt >= oneThirdtyDays && r.IsDeleted == true).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Report>> getAllReportsInADayBefore_finished()
        {
            var oneDayAgo = DateTime.UtcNow.AddDays(-1);
            var result = await context.Reports
              .Where(r => r.ReportedAt >= oneDayAgo && r.IsDeleted == true).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<PostReportDto>> getReportedPost_sortByNumberOfReport()
        {
            var result = await context.Posts
                        .Where(p => context.Reports.Any(r => r.PostId == p.Id&&r.IsDeleted==false))  // Chỉ lấy bài có báo cáo
                        .Select(p => new PostReportDto
                        {
                            Id = p.Id,
                            Title = p.Title,
                            Tryandexpecting = p.Tryandexpecting,
                            CreatedAt = p.CreatedAt,
                            UpdatedAt = p.UpdatedAt,
                            Images = p.Images,
                            reportCount = context.Reports
                            .Where(r => r.PostId == p.Id)  
                            .Count()
                        })
                        .Where(p => p.reportCount > 0)
                        .OrderByDescending(p => p.reportCount)  // Sắp xếp giảm dần
                        .ToListAsync();
            return result;
        }

        public async Task<bool> checkUserReport(Guid userId, Guid postId)
        {
            return await context.Reports.Where(r => r.UserId== userId && r.PostId == postId).AnyAsync();
        }
        public async Task<bool> 
    }
}
