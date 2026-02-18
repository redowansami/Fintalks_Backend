using Fintalks.Common.Constants;
using Fintalks.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Fintalks.Api.Validator
{
    public class CustomValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context
                    .ModelState.Values.Where(v => v.Errors.Count > 0)
                    .SelectMany(v => v.Errors)
                    .Select(v => v.ErrorMessage)
                    .ToList();

                var responseObject = new ErrorResponse
                {
                    Success = false,
                    Message = ErrorConst.Message.validationError,
                    Errors = errors,
                    Stack = null,
                };

                context.Result = new JsonResult(responseObject)
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                };
            }
        }
    }
}
