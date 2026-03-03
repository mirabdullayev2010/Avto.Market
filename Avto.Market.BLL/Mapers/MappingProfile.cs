using AutoMapper;
using Auto.Market.Models;
using Avto.Market.Shared.DTOs.Car;
using Auto.Market.DTOs.Category;

namespace Avto.Market.BLL.Mapers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CarForCreateDto, Car>();
        CreateMap<CarForUpdateDto, Car>();

        CreateMap<Car, CarForResultDto>()
    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty));

        // 2. Category mapping
        CreateMap<Category, CategoryForResultDto>();
        CreateMap<CategoryForResultDto, Category>();
        CreateMap<CategoryForCreateDto, Category>();
        CreateMap<CategoryForUpdateDto, Category>();
    }
}