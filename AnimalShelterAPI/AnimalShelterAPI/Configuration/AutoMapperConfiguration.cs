using AnimalShelterAPI.Models;
using AnimalShelterAPI.Models.DTO;
using AutoMapper;
using System;

namespace AnimalShelterAPI.Configuration
{
    public class AutoMapperConfiguration : Profile 
    {
        public AutoMapperConfiguration() : this("AnimalShelterApi")
        {

        }

        protected AutoMapperConfiguration(string name): base(name)
        {
            CreateMap<Animal, AnimalDto>();
            CreateMap<AnimalDto, Animal>();
            CreateMap<Animal, AnimalListItemDto>();
            CreateMap<Animal, NewAnimalDto>()
                .ForMember(dest => dest.Years, opt => opt.MapFrom(src => src.Birthday == null ? 0 : (DateTime.Now - src.Birthday.Value).Days / 365 ))
                .ForMember(dest => dest.Months, opt => opt.MapFrom(src => src.Birthday == null ? 0 : ((DateTime.Now - src.Birthday.Value).Days % 365) / 30));
            CreateMap<NewAnimalDto, Animal>().ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => DateTime.Now.AddYears(-src.Years).AddMonths(-src.Months)));
            CreateMap<Animal, EditAnimalDto>()
                .ForMember(dest => dest.Years, opt => opt.MapFrom(src => src.Birthday == null ? 0 : (DateTime.Now - src.Birthday.Value).Days / 365))
                .ForMember(dest => dest.Months, opt => opt.MapFrom(src => src.Birthday == null ? 0 : ((DateTime.Now - src.Birthday.Value).Days % 365) / 30));
            CreateMap<EditAnimalDto, Animal>().ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => DateTime.Now.AddYears(-src.Years).AddMonths(-src.Months)));
        }
    }
}
