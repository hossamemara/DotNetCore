using DotNetCore.ConfigurationClasses;
using Microsoft.Extensions.Options;

namespace DotNetCore.Middleware
{
    public class RateLimitMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ProfilingMiddleware> _logger;
        private static int _counter = 0;
        private static DateTime _lastRequestDate = DateTime.Now;
        private readonly IOptionsSnapshot<RateLimit> _optionsSnapshot;
        public RateLimitMiddleware(RequestDelegate next, ILogger<ProfilingMiddleware> logger, IOptionsSnapshot<RateLimit> optionsSnapshot)
        {
            _next = next;
            _logger = logger;
            _optionsSnapshot = optionsSnapshot;
        }
        public async Task Invoke(HttpContext context)
        {
            var localPort = context.Connection.LocalPort.ToString() ?? "unknown";
            _counter++;
            if (DateTime.Now.Subtract(_lastRequestDate).Seconds > _optionsSnapshot.Value.Count)
            {
                _counter = 1;
                _lastRequestDate = DateTime.Now;
                await _next(context);
            }
            else
            {
                if (_counter > _optionsSnapshot.Value.Limit)
                {

                    _lastRequestDate = DateTime.Now;
                    context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                    await context.Response.WriteAsync($"Rate Limit Exceeded at port {localPort}");
                }
                else
                {
                    _lastRequestDate = DateTime.Now;
                    await _next(context);
                }
            }
        }

    }
}
