using AutoMapper;
using FitnessWeb.API.ViewModels;
using FitnessWeb.Models;

namespace FitnessWeb.API.MapperProfiles
{
    public class FitnessMapperProfile : Profile
    {
        public FitnessMapperProfile()
        {
            this.CreateMap<FitnessProgram,FitnessProgramViewModel>();
            this.CreateMap<Exercise,ExerciseViewModel>();
            this.CreateMap<FitnessTip,FitnessTipViewModel>();
            this.CreateMap<Training,TrainingViewModel>();
        }
    }
}
