using Microsoft.AspNetCore.Mvc.Filters;
using AspNetTailwind.ApplicationCore.Models;
using AspNetTailwind.Web.Extensions;
using AspNetTailwind.Web.Models;

namespace AspNetTailwind.Web.Filters
{
    public class AuditLogActionFilter : ActionFilterAttribute
    {
        private readonly ILogger _logger;

        public AuditLogActionFilter(ILogger logger)
        {
            _logger = logger;
        }

        public override Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            var auditLog = new AuditLog(
                context.HttpContext.Request.Path,
                context.HttpContext.Request.Method,
                context.HttpContext.GetRemoteIpAddress(),
                context.HttpContext.GetUserAgent(),
                context.HttpContext.User?.GetName());

            _logger.LogInformation("{AuditLog}", auditLog);

            return base.OnActionExecutionAsync(context, next);
        }
    }
}
