using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using _16_March.Models;
using System;
using System.Diagnostics;

namespace _16_March.CustomFilter
{
    public class AppExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IModelMetadataProvider modelMetadata;
        private readonly EnterpriseContext ctx;
        public AppExceptionFilterAttribute(IModelMetadataProvider modelMetadata, EnterpriseContext ctx)
        {
            this.modelMetadata = modelMetadata;
            this.ctx = new EnterpriseContext();
        }

        public override void OnException(ExceptionContext context)
        {
            
            // 1. Handle Exception to Complete the Execution Process
            context.ExceptionHandled = true;
            // 2. Read the Exception MEssage
            Exception exception = context.Exception;
            // 3. Start the Result Generation Process
            // a. Define a ViewResult Object
            ViewResult viewResult = new ViewResult();
            // b. Set the View NAme (either Standard Error View or Create a Custom View)
            if (exception.GetType().Name == "Exception")
            {
                viewResult.ViewName = "DbError";
                
            }
            else
            {
                viewResult.ViewName = "CustomError";
            }
            // c. Since the View Needs data, we need to use the ViewDataDictionary
            // modelMetadata: The Current Model used in Request
            // ModelState: State of all Values for Model Objet in Current Request
            ViewDataDictionary valuePairs = new ViewDataDictionary(modelMetadata, context.ModelState);
            // d. define keys for ViewDataDictionary so that they can be passed to View
            valuePairs["ControllerName"] = context.RouteData.Values["controller"].ToString();
            valuePairs["ActionName"] = context.RouteData.Values["action"].ToString();
            valuePairs["Message"] = exception.Message;
            // e. pass the valuePairs to ViewData property of ViewResult
            viewResult.ViewData = valuePairs;
            // f. Set the Result property of ExceptionContext to ViewResult
            context.Result = viewResult;

            var timeSpan = Stopwatch.StartNew();
            LogExecution Newexception = new LogExecution()
            {
                ControllerName = valuePairs["controllername"].ToString(),
                ActionName = valuePairs["actionname"].ToString(),
                RequestDateTime = System.DateTime.Now,
                ExecutionCompletionTime = timeSpan.Elapsed.TotalMilliseconds.ToString(),
                ExceptionMessage = valuePairs["message"].ToString(),
                ExceptionType = exception.GetType().ToString(),
            };

            ctx.LogExecutions.Add(Newexception);
            ctx.SaveChanges();

        }

    }
}
