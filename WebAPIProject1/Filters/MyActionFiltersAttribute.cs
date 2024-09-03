using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPIProject1.Filters
{
    public class MyActionFiltersAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //write Any Logic
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //write Any Logic
            base.OnActionExecuted(context);
        }
    }
}
