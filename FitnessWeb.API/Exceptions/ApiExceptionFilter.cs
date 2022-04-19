using FitnessWeb.API.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FitnessWeb.API
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if(context.Exception is ApiException apiExceptionFilter)
            {
                context.Result = new ObjectResult(apiExceptionFilter.Message) { StatusCode = (int)apiExceptionFilter.Code };
            }
        }
    }
}
