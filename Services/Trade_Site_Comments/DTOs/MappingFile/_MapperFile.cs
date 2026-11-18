using AutoMapper;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Trade_Site_Comments.Entity;

namespace Trade_Site_Comments.DTOs.MappingFile
{
    public class _MapperFile : Profile
    {
        public _MapperFile() 
        {
        CreateMap<AddCommentDto, Comment>().ReverseMap();
        CreateMap<UpdateCommentDto, Comment>().ReverseMap();
        CreateMap<ShowCommentDto, Comment>().ReverseMap();
        CreateMap<GetCommentWithProductID, Comment>().ReverseMap();

        }

    }
}
