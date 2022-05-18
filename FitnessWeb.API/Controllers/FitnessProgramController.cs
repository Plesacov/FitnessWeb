using FitnessWeb.API.Commands;
using FitnessWeb.API.Pagination;
using FitnessWeb.API.Queries;
using FitnessWeb.API.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWeb.API.Controllers
{
    [Route("api/fitnessPrograms")]
    [ApiController]
    public class FitnessProgramController : ControllerBase
    {
        private readonly IMediator mediator;
        public FitnessProgramController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("getAll/{searchTerm}")]
        public ActionResult<List<FitnessProgramViewModel>> GetAll(string searchTerm)
        {
            Task<List<FitnessProgramViewModel>> result = this.mediator.Send(new FitnessProgramQuery { SearchTerm = searchTerm });
            return result.Result;
        }

        [HttpPost("createNewProgram")]
        public ActionResult<int> CreateNewProgram([FromBody] CreateFitnessProgramCommand command)
        {
            Task<int> result = this.mediator.Send(command);
            return result.Result;
        }

        [HttpPut("updateFitnessProgram")]
        [ApiExceptionFilter]
        public IActionResult UpdateFitnessProgram([FromBody] UpdateFitnessProgramCommand command)
        {
            this.mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("deleteFitnessProgram/{id}")]
        public IActionResult DeleteFitnessProgram(int id)
        {
            this.mediator.Send(new DeleteFitnessProgramCommand { Id = id});
            return NoContent();
        }

        [HttpPatch("partialUpdateFitnessProgram")]
        [ApiExceptionFilter]
        public IActionResult PartialUpdateFitnessProgram([FromBody] PartialUpdateFitnessProgramCommand command)
        {
            this.mediator.Send(command);
            return NoContent();
        }

        [HttpGet("getById/{id}")]
        [ApiExceptionFilter]
        public ActionResult<FitnessProgramViewModel> GetById(int id)
        {
            Task<FitnessProgramViewModel> result = this.mediator.Send(new SearchByIdFitnessProgramQuery { Id = id });

            if(result == null)
            {
                return BadRequest("Entity is not found");
            }
            return result.Result;
        }

        [HttpPost("getFitnessProgram")]
        [ApiExceptionFilter]
        public IActionResult GetFitnessProgram([FromBody] AssignFitnessProgramToUserCommand command)
        {
            Task<FitnessProgramViewModel> result = this.mediator.Send(command);
            if (result == null)
            {
                return BadRequest("IT Error");
            }
            return NoContent();
        }

        [HttpGet("getAllFitnessTypes")]
        public ActionResult<List<FitnessTypeViewModel>> GetAllFitnessTypes()
        {
            Task<List<FitnessTypeViewModel>> result = this.mediator.Send(new FitnessTypesQuery());
            return result.Result;
        }

        [HttpPost("paginatedFitnessTypes")]
        public ActionResult<PagedCollectionResponse<FitnessTypeViewModel>> PaginatedFitnessTypes([FromBody] FilterModel filterModel)
        {
            Task<PagedCollectionResponse<FitnessTypeViewModel>> result = this.mediator.Send(new PagenatedFitnessProgramQuery { Filter = filterModel});
            return result.Result;
        }

        [HttpPost("paginatedFitnessTips")]
        public ActionResult<PagedCollectionResponse<FitnessTipViewModel>> PaginatedFitnessTips([FromBody] FilterModel filterModel)
        {
            Task<PagedCollectionResponse<FitnessTipViewModel>> result = this.mediator.Send(new FitnessTipsQuery { Filter = filterModel });
            return result.Result;
        }

        [HttpPost("paginatedFitnessTraining")]
        public ActionResult<PagedCollectionResponse<TrainingViewModel>> PaginatedFitnessTraining([FromBody] FilterModel filterModel)
        {
            Task<PagedCollectionResponse<TrainingViewModel>> result = this.mediator.Send(new FitnessTrainingsQuery { Filter = filterModel });
            return result.Result;
        }

        [HttpPost("createNewTip")]
        public ActionResult<int> CreateNewTip([FromBody] CreateFitnessTipCommand command)
        {
            Task<int> result = this.mediator.Send(command);
            return result.Result;
        }

        [HttpPut("updateFitnessTip")]
        [ApiExceptionFilter]
        public IActionResult UpdateFitnessTip([FromBody] UpdateFitnessTipCommand command)
        {
            this.mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("deleteFitnessTip/{id}")]
        public IActionResult DeleteFitnessTip(int id)
        {
            this.mediator.Send(new DeleteFitnessTipCommand { Id = id });
            return NoContent();
        }

        [HttpPost("createNewTraining")]
        public ActionResult<int> CreateNewTraining([FromBody] CreateFitnessTrainingCommand command)
        {
            Task<int> result = this.mediator.Send(command);
            return result.Result;
        }

        [HttpPut("updateFitnessTrainig")]
        [ApiExceptionFilter]
        public IActionResult UpdateFitnessTraining([FromBody] UpdateFitnessTrainingCommand command)
        {
            this.mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("deleteFitnessTraining/{id}")]
        public IActionResult DeleteFitnessTraining(int id)
        {
            this.mediator.Send(new DeleteFitnessTrainingCommand { Id = id });
            return NoContent();
        }
    }
}
