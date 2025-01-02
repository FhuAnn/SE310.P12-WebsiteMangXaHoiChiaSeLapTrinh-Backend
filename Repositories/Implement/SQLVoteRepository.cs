using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Get;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories.Implement
{
    public class SQLVoteRepository : IVoteRepository
    {
        private readonly Stackoverflow1511Context context;

        public SQLVoteRepository(Stackoverflow1511Context context)
        {
            this.context = context;
        }
        public async Task<Vote> VotePost(Vote vote)
        {
            var existingVote = await context.Votes.FirstOrDefaultAsync(v => v.UserId == vote.UserId && v.PostId == vote.PostId);
            if (existingVote != null)
            {
                if (existingVote.VoteType == vote.VoteType)
                {
                    context.Votes.Remove(existingVote);  // Hủy vote nếu nhấn lần nữa
                }
                else
                {
                    existingVote.VoteType = vote.VoteType;  // Cập nhật upvote/downvote
                }
                await context.SaveChangesAsync();
                return existingVote;
            }
            else
            {
                Vote newVote = new Vote
                {
                    UserId = vote.UserId,
                    PostId = vote.PostId,
                    VoteType = vote.VoteType
                };
                context.Votes.Add(newVote);
                await context.SaveChangesAsync();
                return newVote;
            }
        }
        public async Task<VoteDetail> GetVoteDetails(Guid postId, Guid userId)
        {
            var isVoted = await context.Votes
            .Where(v => v.PostId == postId && v.UserId == userId)
            .AnyAsync();

            var result = await context.Posts
            .Where(p => p.Id == postId)
            .Select(p => new VoteDetail
            {
                upVotes = p.Votes.Count(v => v.VoteType == 1),
                downVotes = p.Votes.Count(v => v.VoteType == -1),
                isVoted = isVoted
            })
            .FirstOrDefaultAsync();
            return result ?? new VoteDetail { upVotes = 0, downVotes = 0,isVoted=false };
        }
    }
}
