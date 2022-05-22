using AutoMapper;
using Fitness.Infrastracture;
using FitnessWeb.API.Queries;
using FitnessWeb.API.ViewModels;
using FitnessWeb.Models;
using MediatR;

namespace FitnessWeb.API.QueryHandlers
{
    public class GetAllTrainingsQueryHandler : IRequestHandler<GetAllTrainingsQuery, List<TrainingViewModel>>
    {
        private readonly IRepository<Training> fitnessTrainingRepository;
        private readonly IMapper mapper;
        public GetAllTrainingsQueryHandler(IRepository<Training> fitnessTrainingRepository, IMapper mapper)
        {
            this.fitnessTrainingRepository = fitnessTrainingRepository;
            this.mapper = mapper;
        }
        public Task<List<TrainingViewModel>> Handle(GetAllTrainingsQuery request, CancellationToken cancellationToken)
        {
            var fitnessTrainings = fitnessTrainingRepository.GetAll().ToList();
            var result = mapper.Map<List<TrainingViewModel>>(fitnessTrainings);
            return Task.FromResult(result);
        }
    }
}
