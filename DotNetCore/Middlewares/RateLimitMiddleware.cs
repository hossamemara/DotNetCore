namespace DotNetCore.Middlewares
{
    public class RateLimitMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ProfilingMiddleware> _logger;
        private static int _counter = 0;
        private static DateTime _lastRequestDate = DateTime.Now;
        private const int LIMIT = 5; // Max 5 requests
        private const int WINDOW_SECONDS = 10; // per 10 seconds
        public RateLimitMiddleware(RequestDelegate next, ILogger<ProfilingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            var localPort = context.Connection.LocalPort.ToString() ?? "unknown";
            _counter++;
            if (DateTime.Now.Subtract(_lastRequestDate).Seconds > WINDOW_SECONDS)
            {
                _counter = 1;
                _lastRequestDate = DateTime.Now;
                await _next(context);
            }
            else
            {
                if (_counter > LIMIT)
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
