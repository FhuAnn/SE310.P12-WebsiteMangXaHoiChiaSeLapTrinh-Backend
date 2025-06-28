﻿using AutoMapper;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.Domain;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Add;
using SE310.P12_WebsiteMangXaHoiChiaSeLapTrinh.Models.DTO.Get;
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
            CreateMap<Answer, HomeAnswerDto>().ReverseMap();
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Post, HomePostDto>().ReverseMap();
            CreateMap<Post, AddPostRequestDto>().ReverseMap();
            CreateMap<Post, UpdatePostRequestDto>().ReverseMap();
            CreateMap<Vote,AddVote>().ReverseMap();
            CreateMap<Vote,VoteDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Comment, AddCommentRequestDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentRequestDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Role, AddRoleRequestDto>().ReverseMap();
            CreateMap<Role, UpdateRoleRequestDto>().ReverseMap();
            CreateMap<Posttag, PosttagDto>().ReverseMap();
            CreateMap<Posttag,HomePostTagDto>().ReverseMap();
            CreateMap<Tag, TagDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, HomeUserDto>().ReverseMap();
            CreateMap<User, MinimalUser>().ReverseMap();
            CreateMap<Posttag, PosttagDto>().ReverseMap();
            CreateMap<Image, ImageDto>().ReverseMap();
            CreateMap<UserRole, UserRoleDto>().ReverseMap();
            CreateMap<TopPostsDto, Post>().ReverseMap();
            CreateMap<AuthenUserDto, User>().ReverseMap();
            CreateMap<UpdateUserRequestDto, User>().ReverseMap();
            CreateMap<AddTagRequestDto, Tag>().ReverseMap();
            CreateMap<GetTagDto, Tag>().ReverseMap();
            CreateMap<AnswerPostDto, Post>().ReverseMap();
            CreateMap<Report, AddReport>().ReverseMap();
            CreateMap<Report, ReportDto>().ReverseMap();

        }
    }
}
