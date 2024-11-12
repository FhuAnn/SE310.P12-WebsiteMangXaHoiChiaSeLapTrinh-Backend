using Microsoft.EntityFrameworkCore;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using System.Xml.Linq;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories.Implement
{
    public class SQLCommentRepository : StackOverflowRepository<Comment>, ICommentRepository
    {
        private readonly StackOverflowDBContext dbContext;

        public SQLCommentRepository(StackOverflowDBContext dbContext) : base(dbContext)
        {
                this.dbContext = dbContext;
        }
    }
}
