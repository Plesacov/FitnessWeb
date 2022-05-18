using AutoMapper;
using Fitness.Core.Models;
using FitnessWeb.API.Commands;
using FitnessWeb.API.Identity;
using FitnessWeb.API.ViewModels;
using FitnessWeb.Models;

namespace FitnessWeb.API.MapperProfiles
{
    public class FitnessMapperProfile : Profile
    {
        public FitnessMapperProfile()
        {
            this.CreateMap<FitnessProgram, FitnessProgramViewModel>()
                .ForMember(x => x.Type, y => y.MapFrom(z => z.FitnessType));
            this.CreateMap<Exercise, ExerciseViewModel>();
            this.CreateMap<FitnessTip, FitnessTipViewModel>()
                .ForMember(u => u.FitnessProgramName, opt => opt.MapFrom(x => x.FitnessProgram.FitnessType.Name));
            this.CreateMap<Training, TrainingViewModel>()
                .ForMember(u => u.FitnessProgramName, opt => opt.MapFrom(x => x.FitnessProgram.FitnessType.Name));
            this.CreateMap<FitnessType, FitnessTypeViewModel>()
                .ForMember(x => x.Id,y => y.MapFrom(z => z.FitnessProgramId));
            this.CreateMap<UploadImageCommand, Image>();
            this.CreateMap<Person, PersonDataDto>()
                .ForMember(u => u.FitnessLevel, opt => opt.MapFrom(x => x.FitnessLevel.ToString()))
                .ForMember(u => u.Gender, opt => opt.MapFrom(x => x.Gender.ToString()));

            CreateMap<UserForRegistrationDto, Person>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email))
                .ForMember(u => u.BirthdayDate, opt => opt.MapFrom(x => x.Birthdate));
        }
    }
}
