using AutoMapper;
using Fitness.Core.Models;
using Fitness.Infrastracture;
using FitnessWeb.API.Commands;
using FitnessWeb.API.ViewModels;
using FitnessWeb.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FitnessWeb.API.CommandHandlers
{
    public class AssignFitnessProgramToUserCommandHandler : IRequestHandler<AssignFitnessProgramToUserCommand, FitnessProgramViewModel>
    {
        private readonly IRepository<FitnessProgram> fitnessProgramRepository;
        private readonly IMapper mapper;
        private readonly IRepository<Person> userManager;
        public AssignFitnessProgramToUserCommandHandler(
            IRepository<FitnessProgram> fitnessProgramRepository,
            IMapper mapper,
            IRepository<Person> userManager)
        {
            this.fitnessProgramRepository = fitnessProgramRepository;
            this.mapper = mapper;
            this.userManager = userManager;
        }
        public Task<FitnessProgramViewModel> Handle(AssignFitnessProgramToUserCommand request, CancellationToken cancellationToken)
        {
            var fitnessProgram = this.fitnessProgramRepository.FindBy(x => x.FitnessTypeId == request.FitnessTypeId).FirstOrDefault();
            if (fitnessProgram != null)
            {
                Person user = this.userManager.GetWithInclude(x => x.Id == request.UserId, x => x.PersonFitnessPrograms)?.FirstOrDefault();
                if (user != null)
                {
                    switch (request.FitnessLevel)
                    {
                        case "Begginer":
                            user.FitnessLevel = FitnessLevel.Beginner; 
                            break;
                        case "Middle":
                            user.FitnessLevel = FitnessLevel.Middle;
                            break;
                        case "Advanced":
                            user.FitnessLevel = FitnessLevel.Advanced;
                            break;
                    }
                    user.PersonFitnessPrograms.ForEach(x => x.IsCurrent = false);
                    var personFitnessProgram = user.PersonFitnessPrograms.Find(x => x.FitnessProgramId == fitnessProgram.Id);
                    if (personFitnessProgram != null)
                    {
                        personFitnessProgram.IsCurrent = true;
                    }
                    else
                    {
                        user.PersonFitnessPrograms.Add(new PersonFitnessProgram
                        {
                            PersonId = user.Id,
                            FitnessProgramId = fitnessProgram.Id,
                            IsCurrent = true
                        });
                    }
                    this.fitnessProgramRepository.Save();
                }
            }

            return Task.FromResult(mapper.Map<FitnessProgramViewModel>(fitnessProgram));
        }
    }
}
