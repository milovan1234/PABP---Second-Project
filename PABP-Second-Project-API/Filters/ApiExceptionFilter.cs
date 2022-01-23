using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PABP_Second_Project_API.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is Exception)
            {
                this.HandleException(context, StatusCodes.Status400BadRequest);
                return;
            }

            context.ExceptionHandled = false;
        }

        private void HandleException(ExceptionContext context, int statusCode)
        {
            context.HttpContext.Response.StatusCode = statusCode;
            context.Result = new ObjectResult(new ApiResponse { Message = context.Exception.Message });
            context.ExceptionHandled = true;
        }
    }
}
