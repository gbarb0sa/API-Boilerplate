using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Web.Filters
{
    public class HttpResultActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result != null)
            {
                var objectResult = (ObjectResult)context.Result;

                dynamic responseValue = objectResult;

                if (!responseValue.Value.HasError) return;

                if (responseValue.Value.HttpStatusCode == HttpStatusCode.BadRequest)
                    context.Result = new BadRequestObjectResult(responseValue.Value);
                else if (responseValue.Value.HttpStatusCode == HttpStatusCode.NotFound)
                    context.Result = new NotFoundObjectResult(responseValue.Value);
            }
        }
    }
}