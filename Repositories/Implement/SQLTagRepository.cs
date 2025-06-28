using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories.Implement
{
    public class SQLTagRepository : StackOverflowRepository<Tag>, ITagRepository
    {
        private readonly Stackoverflow1511Context context;

        public SQLTagRepository(Stackoverflow1511Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<bool> DeleteTagAsync(Guid id)
        {
            var tag = await context.Tags.FindAsync(id);
            if (tag == null)
            {
                return false; // Nếu không tìm thấy tag, trả về false
            }

            // Xóa các liên kết trong bảng PostTag liên quan đến tag này
            var postTags = context.Posttags.Where(pt => pt.TagId == id).ToList();
            context.Posttags.RemoveRange(postTags);

            // Xóa tag khỏi bảng Tags
            context.Tags.Remove(tag);

            try
            {
                // Lưu các thay đổi vào database
                await context.SaveChangesAsync();
                return true; // Xóa thành công
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine(ex.Message);
                return false; // Nếu có lỗi, trả về false
            }
        }

        public async Task<List<Tag>> GetTagsAsync()
        {
            var tags = await context.Tags
               .Select(p => new Tag
               {
                   Id = p.Id,
                   Tagname = p.Tagname,
                   Description = p.Description,
                   CreatedAt = p.CreatedAt,
                   UpdatedAt = p.UpdatedAt,

                   Posttags = p.Posttags.Select(pt => new Posttag
                   {
                       PostId = pt.PostId,
                       Post = pt.Post
                   }).ToList()
               }).ToListAsync();

            return tags;
        }

        public  async Task<List<Tag>> SearchTagAsync(string searchTerm)
        {
            var results = await context.Tags
                .Where(x => EF.Functions.Like(x.Tagname, $"%{searchTerm}%"))
                .Take(5)
                .ToListAsync();
            return results;
        }

    }
}
