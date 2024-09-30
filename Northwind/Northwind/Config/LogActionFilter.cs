using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Northwind.Config
{
    public class LogActionFilter : IActionFilter
    {
        private readonly ILogger<LogActionFilter> _logger;
        public LogActionFilter(ILogger<LogActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context?.Result is ObjectResult objResult)
                _logger.LogDebug($"Response:{JsonConvert.SerializeObject(objResult.Value)}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogDebug($"Request:{JsonConvert.SerializeObject(context.ActionArguments)}");
        }
    }
}
