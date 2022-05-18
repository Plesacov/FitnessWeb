using AutoMapper;
using Fitness.Infrastracture;
using FitnessWeb.API.Pagination;
using FitnessWeb.API.Queries;
using FitnessWeb.API.ViewModels;
using FitnessWeb.Models;
using MediatR;

namespace FitnessWeb.API.QueryHandlers
{
    public class FitnessTipsQueryHandler : IRequestHandler<FitnessTipsQuery, PagedCollectionResponse<FitnessTipViewModel>>
    {
        private readonly IRepository<FitnessTip> fitnesTipRepository;
        private readonly IMapper mapper;

        public FitnessTipsQueryHandler(IRepository<FitnessTip> fitnessProgramRepository, IMapper mapper)
        {
            this.fitnesTipRepository = fitnessProgramRepository;
            this.mapper = mapper;
        }
        public Task<PagedCollectionResponse<FitnessTipViewModel>> Handle(FitnessTipsQuery request, CancellationToken cancellationToken)
        {
            var propertyInfo = typeof(FitnessTip);
            var property = propertyInfo.GetProperty(request.Filter.SortedField ?? "Name");
            var fitnessTips = this.fitnesTipRepository.GetWithInclude(x => x.FitnessProgram != null,x => x.FitnessProgram, x => x.FitnessProgram.FitnessType);

            if (string.IsNullOrEmpty(request.Filter.Term) || request.Filter.Term == "")
            {
                fitnessTips = request.Filter.SortAsc
                    ? fitnessTips.OrderBy(p => property.GetValue(p)).ToList()
                    : fitnessTips.OrderByDescending(p => property.GetValue(p)).ToList();
                var fitnessTipsViewModels = mapper.Map<List<FitnessTipViewModel>>(fitnessTips);
            }
            else
            {
                fitnessTips = fitnessTips.Where(u => u.Name.ToLower().StartsWith(request.Filter.Term) || u.Description.ToLower().StartsWith(request.Filter.Term)).ToList();
                fitnessTips = request.Filter.SortAsc ? fitnessTips.OrderBy(p => property.GetValue(p)).ToList() : fitnessTips.OrderByDescending(p => property.GetValue(p)).ToList();
            }

            var result = PagedCollectionResponse<FitnessTipViewModel>.Create(fitnessTips, request.Filter, (p) => mapper.Map<FitnessTipViewModel>(p));
            return Task.FromResult(result);
        }
    }
}
