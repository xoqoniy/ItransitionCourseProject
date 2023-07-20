using AutoMapper;
using Course_Project.Domain.Entities;
using Course_Project.Service.DTOs.Collections;
using Course_Project.Service.DTOs.Comments;
using Course_Project.Service.DTOs.CustomFields;
using Course_Project.Service.DTOs.Items;
using Course_Project.Service.DTOs.Users;

namespace Course_Project.Service.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<User, UserForCreationDto>().ReverseMap();
        CreateMap<User, UserForResultDto>().ReverseMap();
        CreateMap<User, UserForUpdateDto>().ReverseMap();
        CreateMap<UserForResultDto, UserForUpdateDto>().ReverseMap();
        CreateMap<UserForCreationDto, UserForResultDto>().ReverseMap();

        CreateMap<Collection, CollectionForCreationDto>().ReverseMap();
        CreateMap<Collection, CollectionForResultDto>().ReverseMap();
        CreateMap<Collection, CollectionForUpdateDto>().ReverseMap();

        CreateMap<Comment, CommentForCreationDto>().ReverseMap();
        CreateMap<Comment, CommentForResultDto>().ReverseMap();
        CreateMap<Comment, CommentForEditDto>().ReverseMap();

        CreateMap<Item, ItemForCreationDto>().ReverseMap();
        CreateMap<Item, ItemForResultDto>().ReverseMap();
        CreateMap<Item, ItemForUpdateDto>().ReverseMap();

        CreateMap<CustomField, CustomFieldForCreationDto>().ReverseMap();
        CreateMap<CustomField, CustomFieldForResultDto>().ReverseMap();
    }
}
