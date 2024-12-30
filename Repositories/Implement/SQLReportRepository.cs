using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using Microsoft.EntityFrameworkCore;

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
    }
}
