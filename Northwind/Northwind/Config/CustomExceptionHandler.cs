using Microsoft.AspNetCore.Diagnostics;

namespace Northwind.Config
{
    public class CustomExceptionHandler : IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            var exceptionMessage = exception.Message;
            var logWriter = new LogWriter(exceptionMessage);
            return ValueTask.FromResult(false);
        }
    }
}
