using AutoMapper;
using Fitness.Core.Models;
using Fitness.Infrastracture;
using FitnessWeb.API.Commands;
using FitnessWeb.Models;
using MediatR;


namespace FitnessWeb.API.CommandHandlers
{
    public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, Unit>
    {
        private readonly IRepository<Person> personRepository;
        private readonly IMapper mapper;
        public UploadImageCommandHandler(IRepository<Person> personRepository, IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }
        public Task<Unit> Handle(UploadImageCommand request, CancellationToken cancellationToken)
        {
            Person person = this.personRepository.GetWithInclude(x => x.Id == request.UserId, x => x.Images)?.FirstOrDefault();
            if (person != null)
            {
                person.Images.Add(new Image
                {
                    Id = request.UserId,
                    ImageTitle = person.FirstName
                });
                this.personRepository.Save();
            }
            return Task.FromResult(new Unit());
        }
    }
}
