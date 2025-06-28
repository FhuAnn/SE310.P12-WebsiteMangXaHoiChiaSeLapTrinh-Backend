using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Services.Implement
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IUserRepository _userRepository;

        public CommentService(
            ICommentRepository commentRepository,
            IPostRepository postRepository,
            IAnswerRepository answerRepository,
            IUserRepository userRepository)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
            _answerRepository = answerRepository;
            _userRepository = userRepository;
        }

        public async Task<Comment> AddCommentToPostAsync(Guid postId, string body, Guid userId)
        {
            var post = await _postRepository.GetByIdAsync(x => x.Id == postId);
            if (post == null)
            {
                throw new Exception("Post not found.");
            }

            var user = await _userRepository.GetByIdAsync(x => x.Id == userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            var comment = new Comment
            {
                PostId =postId,
                Body = body,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                UserId = userId
            };

            return await _commentRepository.AddCommentAsync(comment);
        }

        public async Task<Comment> AddCommentToAnswerAsync(Guid answerId, string body, Guid userId)
        {
            var answer = await _answerRepository.GetByIdAsync(x => x.Id == answerId);
            if (answer == null)
            {
                throw new Exception("Answer not found.");
            }

            var user = await _userRepository.GetByIdAsync(x => x.Id == userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            var comment = new Comment
            {
                AnswerId = answerId,
                Body = body,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                UserId = userId
            };

            return await _commentRepository.AddCommentAsync(comment);
        }



        public async Task<IEnumerable<Comment>> GetCommentsByPostAsync(Guid postId)
        {
            return await _commentRepository.GetCommentsByPostAsync(postId);
        }

        public async Task<IEnumerable<Comment>> GetCommentsByAnswerAsync(Guid answerId)
        {
            return await _commentRepository.GetCommentsByAnswerAsync(answerId);
        }
        // Cập nhật phương thức sửa bình luận
        public async Task<Comment> UpdateCommentAsync(Guid commentId, string newBody, Guid userId)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(commentId);
            if (comment == null) throw new Exception("Comment not found.");
            if (comment.UserId != userId) throw new Exception("User can only update their own comment.");

            comment.Body = newBody;
            comment.UpdatedAt = DateTime.UtcNow;

            return await _commentRepository.UpdateCommentAsync(comment);
        }

        // Cập nhật phương thức xóa bình luận
        public async Task<bool> DeleteCommentAsync(Guid commentId, Guid userId)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(commentId);
            if (comment == null) throw new Exception("Comment not found.");
            if (comment.UserId != userId) throw new Exception("User can only delete their own comment.");

            return await _commentRepository.DeleteCommentAsync(commentId);
        }
    }

}
