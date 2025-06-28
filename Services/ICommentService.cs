﻿using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Services
{
    public interface ICommentService
    {
        Task<Comment> AddCommentToPostAsync(Guid postId, string body, Guid userId);
        Task<Comment> AddCommentToAnswerAsync(Guid answerId, string body, Guid userId);
        Task<Comment> UpdateCommentAsync(Guid commentId, string newBody, Guid userId);
        Task<bool> DeleteCommentAsync(Guid commentId, Guid userId);
        Task<IEnumerable<Comment>> GetCommentsByPostAsync(Guid postId);
        Task<IEnumerable<Comment>> GetCommentsByAnswerAsync(Guid postId);

    }

}
