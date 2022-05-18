using Fitness.Core.Models;
using Fitness.Infrastracture;
using FitnessWeb.API.Commands;
using FitnessWeb.Models;
using MediatR;

namespace FitnessWeb.API.CommandHandlers
{
    public class UpdateFitnessTipCommandHandler : IRequestHandler<UpdateFitnessTipCommand, Unit>
    {
        private readonly IRepository<FitnessTip> fitnessTipRepository;
        public UpdateFitnessTipCommandHandler(IRepository<FitnessTip> fitnessTipRepository)
        {
            this.fitnessTipRepository = fitnessTipRepository;
        }
        public Task<Unit> Handle(UpdateFitnessTipCommand request, CancellationToken cancellationToken)
        {
            var fitnessTip = this.fitnessTipRepository.FindBy(x => x.Id == request.Id).FirstOrDefault();
            if (fitnessTip != null)
            {
                fitnessTip.Name = request.Name;
                fitnessTip.Description = request.Description;
                fitnessTipRepository.Update(fitnessTip);
                fitnessTipRepository.Save();
            }

            return Task.FromResult(new Unit());
        }
    }
}
