using AutoMapper;
using Trade_Site_Catalogue.DTOs.CategoryDTOs;
using Trade_Site_Catalogue.DTOs.ProductDTOs;
using Trade_Site_Catalogue.Entity;

namespace Trade_Site_Catalogue.DTOs.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        { 
            CreateMap<InsertCategoryDto,Category>().ReverseMap();
            CreateMap<UpdateCategoryDto,Category>().ReverseMap();   
            CreateMap<ShowCategoryDto,Category>().ReverseMap();   
            CreateMap<GetByIdCategoryDto,Category>().ReverseMap();

            CreateMap<InsertProductDto, Product>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();
            CreateMap<ShowProductDto, Product>().ReverseMap();
            CreateMap<GetByIdProductDto, Product>().ReverseMap();

            CreateMap<InsertProductDto, ProductInfo>().ReverseMap();
            CreateMap<UpdateProductDto, ProductInfo>().ReverseMap();
            CreateMap<ShowProductDto, ProductInfo>().ReverseMap();
            CreateMap<GetByIdProductDto, ProductInfo>().ReverseMap();

            CreateMap<InsertProductDto, ProductPhoto>().ReverseMap();
            CreateMap<UpdateProductDto, ProductPhoto>().ReverseMap();
            CreateMap<ShowProductDto, ProductPhoto>().ReverseMap();
            CreateMap<GetByIdProductDto, ProductPhoto>().ReverseMap();

        }
    }
}
