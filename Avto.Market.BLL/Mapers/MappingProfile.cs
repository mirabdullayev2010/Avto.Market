using AutoMapper;
using Auto.Market.Models;
using Avto.Market.Shared.DTOs.Car;
using Auto.Market.DTOs.Category;

namespace Avto.Market.BLL.Mapers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // 1. Car mapping
        CreateMap<CarForCreateDto, Car>();
        CreateMap<CarForUpdateDto, Car>();

        // MUHIM QISMI:
        CreateMap<Car, CarForResultDto>()
            // Agar CarForResultDto ichidagi Category string bo'lsa, Name-ni olamiz
            // Agar u CategoryForResultDto bo'lsa, .MapFrom(src => src.Category) bo'ladi
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));

        // 2. Category mapping
        CreateMap<Category, CategoryForResultDto>();
        CreateMap<CategoryForResultDto, Category>();
        CreateMap<CategoryForCreateDto, Category>();
        CreateMap<CategoryForUpdateDto, Category>();
    }
}