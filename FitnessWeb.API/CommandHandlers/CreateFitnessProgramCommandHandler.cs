
using AutoMapper;
using Fitness.Core.Models;
using Fitness.Infrastracture;
using FitnessWeb.API.Commands;
using FitnessWeb.Models;
using MediatR;

namespace FitnessWeb.API.CommandHandlers
{
    public class CreateFitnessProgramCommandHandler : IRequestHandler<CreateFitnessProgramCommand, int>
    {
        private readonly IRepository<FitnessProgram> fitnessProgramRepository;
        public CreateFitnessProgramCommandHandler(IRepository<FitnessProgram> fitnessProgramRepository)
        {
            this.fitnessProgramRepository = fitnessProgramRepository;
        }
        public Task<int> Handle(CreateFitnessProgramCommand command, CancellationToken cancellationToken)
        {
            FitnessProgram fitnessProgram = new FitnessProgram
            {
                FitnessType = new FitnessType
                {
                    Name = command.Name,
                    Description = command.Description
                }
            };

            fitnessProgramRepository.Insert(fitnessProgram);
            fitnessProgramRepository.Save();

            var resultId = fitnessProgram.Id;
            return Task.FromResult(resultId);
        }
    }
}
