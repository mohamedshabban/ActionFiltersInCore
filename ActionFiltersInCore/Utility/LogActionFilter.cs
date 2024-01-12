using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace ActionFiltersInCore.Utility
{
    /// <summary>
    /// logs the start and end time of a controller action method:
    /// </summary>
    public class LogActionFilter: ActionFilterAttribute
    {
        /// <inheritdoc />
        private Stopwatch _stopwatch;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew();
        }

        /// <inheritdoc />
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();
            Console.WriteLine($"The action took {_stopwatch.ElapsedMilliseconds} ms to execute");
        }

    }
}
