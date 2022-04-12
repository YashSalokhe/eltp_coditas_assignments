namespace api.CustomMiddleware
{
    public class ErrorInfo
    {
        public int ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
    public class ExceptionMiddleware
    {
        public readonly RequestDelegate next;
        public ApiDbContext ctx;
        public ExceptionMiddleware(RequestDelegate request)
        {
            next = request;
        }
        /// <summary>
        /// The Method the contains the Middlweare logic
        /// Current Middleware will use try..catch block since it is used for exception handling 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context, ApiDbContext ctx)
        {
            this.ctx = ctx;
            try
            {
                // If no Error then move to next midleware
                await next(context);
            }
            catch (Exception ex)
            {
                // Else Handle an exception and return HTTP Response
                // 1. Set the Statuc code
                context.Response.StatusCode = 500;
                // 2. Read the exception MEssage
                string message = ex.Message;
                string? stacktrace = ex.StackTrace;
                // 3. Set this information to ErrorInfo class
                var errorInfo = new ErrorInfo()
                {
                    ErrorCode = context.Response.StatusCode,
                    ErrorMessage = message
                };

                ExceptionInfo exception = new ExceptionInfo()
                {
                    ControllerName = context.GetRouteValue("controller").ToString(),
                    RequestMethodType = context.Request.Method.ToString(),
                    DateTime = System.DateTime.Now,
                    ErrorMessage = message,
                    StatckTrace = stacktrace,
                };

                await ctx.exceptionInfos.AddAsync(exception);
                ctx.SaveChanges();

                // 4. Write the ErrorInfo object into the Response
                // with JSON Serialization
                await context.Response.WriteAsJsonAsync<ErrorInfo>(errorInfo);
            }
        }
    }

    /// <summary>
    /// AN Extension CLass that provides an extension method
    /// For Registering Custom Middleare into the Http Pipeline  
    /// </summary>
    public static class ErrorInfoExtensions
    {
        public static void UseRequestException(this IApplicationBuilder builder)
        {
            // Registering the CLass as Custom Middleware
            // so that it can be used in Pipeline
            builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
