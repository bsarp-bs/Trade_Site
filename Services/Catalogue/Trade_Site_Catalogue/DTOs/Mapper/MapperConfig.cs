using AutoMapper;
using Trade_Site_Catalogue.DTOs.CategoryDTOs;
using Trade_Site_Catalogue.DTOs.ProductDTOs;
using Trade_Site_Catalogue.DTOs.ProductInfoDTOs;
using Trade_Site_Catalogue.DTOs.ProductPhotoDTOs;
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
            CreateMap<GetProductWithCategory, Product>().ReverseMap();

            CreateMap<InsertProductInfoDto, ProductInfo>().ReverseMap();
            CreateMap<UpdateProductInfoDto, ProductInfo>().ReverseMap();
            CreateMap<ShowProductInfoDto, ProductInfo>().ReverseMap();
            CreateMap<GetByIdProductInfoDto, ProductInfo>().ReverseMap();
            CreateMap<GetProductInfoWithProductID, ProductInfo>().ReverseMap();

            CreateMap<InsertProductPhotoDto, ProductPhoto>().ReverseMap();
            CreateMap<UpdateProductPhotoDto, ProductPhoto>().ReverseMap();
            CreateMap<ShowProductPhotoDto, ProductPhoto>().ReverseMap();
            CreateMap<GetByIdProductPhotoDto, ProductPhoto>().ReverseMap();

        }
    }
}
