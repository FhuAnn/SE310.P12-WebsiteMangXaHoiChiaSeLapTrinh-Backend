﻿using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories
{
    public interface IPostRepository:IStackOverflowRepository<Post>
    {
        Task<Post> GetPostDetailsAsync(Guid id);
        Task<List<Post>> GetPostHomesAsync();
        Task SavePost(Post post);
        Task<List<Post>> GetByTagIdAsync(Guid id);
        Task<List<Post>> GetByUserIdAsync(Guid id);
        Task<Post> GetPostByPostIdAsync(Guid id);
        Task<List<Post>> GetMostAnsweredQuestionAsync();
        Task UpdatePostViewAsync(Post post);
        Task<Post> DeletePostAsync(Guid postId);
        Task<List<Post>> SearchPostByKeyword(string keyword);
    }
}
