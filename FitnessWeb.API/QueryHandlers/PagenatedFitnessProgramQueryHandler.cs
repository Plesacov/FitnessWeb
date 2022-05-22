using AutoMapper;
using Fitness.Core.Models;
using Fitness.Infrastracture;
using FitnessWeb.API.Pagination;
using FitnessWeb.API.Queries;
using FitnessWeb.API.ViewModels;
using MediatR;

namespace FitnessWeb.API.QueryHandlers
{
    public class PagenatedFitnessProgramQueryHandler : IRequestHandler<PagenatedFitnessProgramQuery, PagedCollectionResponse<FitnessTypeViewModel>>
    {
        private readonly IRepository<FitnessType> fitnessProgramRepository;
        private readonly IMapper mapper;
        public PagenatedFitnessProgramQueryHandler(IRepository<FitnessType> fitnessProgramRepository, IMapper mapper)
        {
            this.fitnessProgramRepository = fitnessProgramRepository;
            this.mapper = mapper;
        }
        public Task<PagedCollectionResponse<FitnessTypeViewModel>> Handle(PagenatedFitnessProgramQuery request, CancellationToken cancellationToken)
        {
            var propertyInfo = typeof(FitnessType);
            var property = propertyInfo.GetProperty(request.Filter.SortedField ?? "Name");
            var fitnessTypes = this.fitnessProgramRepository.GetAll();
            if (string.IsNullOrEmpty(request.Filter.Term) || request.Filter.Term == "")
            {
                fitnessTypes = request.Filter.SortAsc
                    ? fitnessTypes.OrderBy(p => property.GetValue(p)).ToList()
                    : fitnessTypes.OrderByDescending(p => property.GetValue(p)).ToList();
                var fitnessTypesViewModels = mapper.Map<List<FitnessTypeViewModel>>(fitnessTypes);

                return Task.FromResult(PagedCollectionResponse<FitnessTypeViewModel>.Create(fitnessTypes, request.Filter, (p) => mapper.Map<FitnessTypeViewModel>(p)));
            }

            fitnessTypes = fitnessTypes.Where(u => u.Name.ToLower().StartsWith(request.Filter.Term) || u.Description.ToLower().StartsWith(request.Filter.Term)).ToList();
            fitnessTypes = request.Filter.SortAsc ? fitnessTypes.OrderBy(p => property.GetValue(p)).ToList() : fitnessTypes.OrderByDescending(p => property.GetValue(p)).ToList();

            var result = PagedCollectionResponse<FitnessTypeViewModel>.Create(fitnessTypes, request.Filter, (p) => mapper.Map<FitnessTypeViewModel>(p));
            return Task.FromResult(result);
        }
    }
}
