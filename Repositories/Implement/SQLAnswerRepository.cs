using Microsoft.EntityFrameworkCore;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories.Implement
{
    public class SQLAnswerRepository : StackOverflowRepository<Answer>,IAnswerRepository
    {
        private readonly StackOverflowDBContext dbContext;

        public SQLAnswerRepository(StackOverflowDBContext dbContext):base(dbContext) 
        {
            this.dbContext = dbContext;
        }
    }
}
