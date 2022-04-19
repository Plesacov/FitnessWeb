using AutoMapper;
using Fitness.Core.Models;
using FitnessWeb.API.Commands;
using FitnessWeb.API.ViewModels;
using FitnessWeb.Models;

namespace FitnessWeb.API.MapperProfiles
{
    public class FitnessMapperProfile : Profile
    {
        public FitnessMapperProfile()
        {
            this.CreateMap<FitnessProgram,FitnessProgramViewModel>()
                .ForMember(x => x.Type, y => y.MapFrom(z => z.FitnessType));
            this.CreateMap<Exercise,ExerciseViewModel>();
            this.CreateMap<FitnessTip,FitnessTipViewModel>();
            this.CreateMap<Training,TrainingViewModel>();
            this.CreateMap<FitnessType, FitnessTypeViewModel>();
        }
    }
}
