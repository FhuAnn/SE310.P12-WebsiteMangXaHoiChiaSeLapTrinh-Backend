using AutoMapper;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Add;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Update;
namespace SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Mapping
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile() 
        { 
            CreateMap<Answer,AnswerDto>().ReverseMap();
            CreateMap<Answer, AddAnswerRequestDto>().ReverseMap();
            CreateMap<Answer, UpdateAnswerRequestDto>().ReverseMap();
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Post, AddPostRequestDto>().ReverseMap();
            CreateMap<Post, UpdatePostRequestDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Comment, AddCommentRequestDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentRequestDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Role, AddRoleRequestDto>().ReverseMap();
            CreateMap<Role, UpdateRoleRequestDto>().ReverseMap();
            CreateMap<Posttag, PosttagDto>().ReverseMap();
            CreateMap<Tag, TagDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Posttag, PosttagDto>().ReverseMap();
            CreateMap<Image, ImageDto>().ReverseMap();
        }
    }
}
