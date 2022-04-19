using FitnessWeb.API.Commands;
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
            var result = this.mediator.Send(command);
            return result.Result;
        }

        [HttpPut("updateFitnessProgram")]
        [ApiExceptionFilter]
        public IActionResult UpdateFitnessProgram([FromBody] UpdateFitnessProgramCommand command)
        {
            this.mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("deleteFitnessProgram")]
        public IActionResult DeleteFitnessProgram([FromBody] DeleteFitnessProgramCommand command)
        {
            this.mediator.Send(command);
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
    }
}
