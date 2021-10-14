using CRMGURU.Data.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CRMGURU.Api.Controllers
{
    [ApiController]
    [ApplicationExceptionFilter]
    public class BaseController : ControllerBase
    {
    }

    public class ApplicationExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case ExceptionExtensions.NotFoundException e:
                    context.Result = new NotFoundObjectResult(e.Message);
                    return;
                case ExceptionExtensions.AlreadyExistException e:
                    context.Result = new ConflictObjectResult(e.Message);
                    return;
            }
        }
    }
}
