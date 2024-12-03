using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Repositories.Implement
{
    public class SQLUserRepository : StackOverflowRepository<User>, IUserRepository
    {
        private readonly StackOverflowDBContext context;

        public SQLUserRepository(StackOverflowDBContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<User> Authenticate(string email, string password)
        {
            var result = await context.Users.SingleOrDefaultAsync(user => user.Email.Equals(email) && user.Password.Equals(password));
            return result;
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            var users = await context.Users
                .Select(u => new User
                {
                    Id = u.Id,
                    Username = u.Username,
                    Gravatar = u.Gravatar,
                    Views = u.Views,
                    CreatedAt = u.CreatedAt,
                    Email = u.Email,
                    Answers = u.Answers.Select(ans => new Answer
                    {
                        Id = ans.Id,
                    }).ToList(),
                    Comments = u.Comments.Select(cmt => new Comment
                    {
                        Id = cmt.Id,
                    }).ToList(),
                    Posts = u.Posts.Select(p=>new Post
                    {
                        Id=p.Id,
                    }).ToList()
                }).ToListAsync();
            return users;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await context.Users
                .Where(u => u.Email == email)
                .Select(u => new User
                {
                    Id = u.Id,
                    Username = u.Username,
                    Gravatar = u.Gravatar,
                    Views = u.Views,
                    CreatedAt = u.CreatedAt,
                    Email = u.Email,
                    Posts = u.Posts.OrderByDescending(p=>p.CreatedAt).ToList(),
                    IgnoredTags = u.IgnoredTags.Select(it => new IgnoredTag
                    {
                        TagId = it.TagId,
                        Tag = new Tag
                        {
                            Tagname = it.Tag.Tagname,
                            Description = it.Tag.Description,
                        },
                    }).ToList(),
                    Answers = u.Answers.OrderByDescending(p => p.CreatedAt).ToList(),
                    Comments = u.Comments.OrderByDescending(p => p.CreatedAt).ToList(),
                    WatchedTags = u.WatchedTags.Select(it => new WatchedTag
                    {
                        TagId = it.TagId,
                        Tag = new Tag
                        {
                            Tagname = it.Tag.Tagname,
                            Description = it.Tag.Description,
                        },
                    }).ToList(),
                    UserRoles = u.UserRoles
                }).SingleOrDefaultAsync();
            return user;
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var users = await context.Users
                .Where(u => u.Id == id)
                .Select(u => new User
                {
                    Id = u.Id,
                    Username = u.Username,
                    Gravatar = u.Gravatar,
                    Views = u.Views,
                    CreatedAt = u.CreatedAt,
                    Email = u.Email,
                    Posts = u.Posts.OrderByDescending(p => p.CreatedAt).ToList(),
                    IgnoredTags = u.IgnoredTags.Select(it => new IgnoredTag
                    {
                        TagId = it.TagId,
                        Tag = new Tag
                        {
                            Tagname = it.Tag.Tagname,
                            Description = it.Tag.Description,
                        },
                    }).ToList(),
                    Answers = u.Answers.OrderByDescending(p => p.CreatedAt).ToList(),
                    Comments = u.Comments.OrderByDescending(p => p.CreatedAt).ToList(),
                    WatchedTags = u.WatchedTags.Select(it => new WatchedTag
                    {
                        TagId = it.TagId,
                        Tag = new Tag
                        {
                            Tagname = it.Tag.Tagname,
                            Description = it.Tag.Description,
                        },
                    }).ToList(),
                    UserRoles = u.UserRoles
                }).SingleOrDefaultAsync();
            return users;
        }
    }
}
