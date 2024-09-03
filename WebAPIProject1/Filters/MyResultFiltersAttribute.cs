using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPIProject1.Filters
{
    public class MyResultFiltersAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            base.OnResultExecuted(context);
        }
    }
}
