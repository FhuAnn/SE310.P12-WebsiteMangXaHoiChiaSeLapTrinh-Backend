using Microsoft.EntityFrameworkCore;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories.Implement
{
    public class SQLAnswerRepository : IAnswerRepository
    {
        private readonly StackOverflowDBContext dbContext;

        public SQLAnswerRepository(StackOverflowDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Answer> CreateAsync(Answer answer)
        {
            await dbContext.Answers.AddAsync(answer);
            await dbContext.SaveChangesAsync();
            return answer;
        }

        public async Task<Answer> DeleteAsync(Guid id)
        {
            var existingAnswer = await dbContext.Answers.FirstOrDefaultAsync(x => x.Id == id);
            if (existingAnswer == null)
            {
                return null;
            }

            dbContext.Answers.Remove(existingAnswer);
            await dbContext.SaveChangesAsync();
            return existingAnswer;
        }

        public async Task<List<Answer>> GetAllAsync()
        {
            return await dbContext.Answers.ToListAsync();
        }

        public async Task<Answer> GetByIdAsync(Guid id)
        {
            return await dbContext.Answers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Answer> UpdateAsync(Guid id, Answer answer)
        {
            var existingAnswer = dbContext.Answers.FirstOrDefault(x => x.Id == id);
            if (existingAnswer == null)
            {
                return null;
            }

            //Only Change Body and UpdateAt
            existingAnswer.UpdatedAt = answer.UpdatedAt;
            existingAnswer.Body = answer.Body;

            await dbContext.SaveChangesAsync();
            return existingAnswer;
        }
    }
}
