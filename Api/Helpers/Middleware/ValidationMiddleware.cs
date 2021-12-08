using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Api.Helpers.Middleware
{
    public class ValidationMiddleware : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var jsonModelValidate = context.ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage).ToList();
                context.Result = new BadRequestObjectResult(new ApiErrorResponse((int)HttpStatusCode.BadRequest, jsonModelValidate[0], jsonModelValidate));
                return;
            }
            await next();
        }
    }
}