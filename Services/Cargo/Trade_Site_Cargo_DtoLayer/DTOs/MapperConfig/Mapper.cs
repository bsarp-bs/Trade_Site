using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Trade_Site_Cargo_EntityLayer.Concrete;
using Trade_Site_Cargo_DtoLayer.DTOs.CargoCabDTOs;
using Trade_Site_Cargo_DtoLayer.DTOs.CargoDetailDTOs;
using Trade_Site_Cargo_DtoLayer.DTOs.CargoOwnerDTOs;
using Trade_Site_Cargo_DtoLayer.DTOs.CargoStatusDTOs;

namespace Trade_Site_Cargo_DtoLayer.DTOs.MapperConfig
{
    public class Mapper : Profile
    {
        public Mapper() 
        {
            CreateMap<GetListCargoDetailDto, CargoDetail>().ReverseMap();
            CreateMap<CreateCargoDetailDto, CargoDetail>().ReverseMap();
            CreateMap<UpdateCargoDetailDto, CargoDetail>().ReverseMap();
            CreateMap<GetByIdCargoDetailDto, CargoDetail>().ReverseMap();
            CreateMap<DeleteCargoDetailDto, CargoDetail>().ReverseMap();

            CreateMap<GetListCargoCabDto, CargoCab>().ReverseMap();
            CreateMap<CreateCargoCabDto, CargoCab>().ReverseMap();
            CreateMap<UpdateCargoCabDto, CargoCab>().ReverseMap();
            CreateMap<GetByIdCargoCabDto, CargoCab>().ReverseMap();
            CreateMap<DeleteCargoCabDto, CargoCab>().ReverseMap();

            CreateMap<GetListCargoOwnerDto, CargoOwner>().ReverseMap();
            CreateMap<CreateCargoOwnerDto, CargoOwner>().ReverseMap();
            CreateMap<UpdateCargoOwnerDto, CargoOwner>().ReverseMap();
            CreateMap<GetByIdCargoOwnerDto, CargoOwner>().ReverseMap();
            CreateMap<DeleteCargoOwnerDto, CargoOwner>().ReverseMap();

            CreateMap<GetListCargoStatusDto, CargoStatus>().ReverseMap();
            CreateMap<CreateCargoStatusDto, CargoStatus>().ReverseMap();
            CreateMap<UpdateCargoStatusDto, CargoStatus>().ReverseMap();
            CreateMap<GetByIdCargoStatusDto, CargoStatus>().ReverseMap();
            CreateMap<DeleteCargoStatusDto, CargoStatus>().ReverseMap();
        }
    }
}
