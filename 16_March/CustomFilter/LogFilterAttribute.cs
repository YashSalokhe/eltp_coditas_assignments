using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Diagnostics;
using _16_March.Models;
using System.Diagnostics;

namespace _16_March.CustomFilter
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
    
        Stopwatch stopwatch = new Stopwatch();
        private readonly EnterpriseContext ctx;
        public LogFilterAttribute(EnterpriseContext ctx)
        {
            this.ctx = new EnterpriseContext();
        }
        private void LogRequest(string currentState, RouteData route)
        {
            //var timeSpan = Stopwatch.StartNew();
            /* string message = $"Current State {currentState} for Exeuting Controller is {route.Values["controller"].ToString()} and Action is {route.Values["action"].ToString()}";
             Debug.WriteLine(message);*/

           
            Log log = new Log()
            {
                ControllerName = route.Values["controller"].ToString(),
                ActionName = route.Values["action"].ToString(),
                RequestDateTime = System.DateTime.Now,
                ExecutionCompletionTime = stopwatch.Elapsed.TotalMilliseconds.ToString(),
            };
            ctx.Logs.Add(log);
            ctx.SaveChanges();
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            stopwatch.Start();
           // LogRequest("OnActionExecuting", context.RouteData);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
           // LogRequest("OnActionExecuted", context.RouteData);
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
           // LogRequest("OnResultExecuting", context.RouteData);
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            stopwatch.Stop();
            LogRequest("OnResultExecuted", context.RouteData);
        }
    }
}
