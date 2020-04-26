using Microsoft.Extensions.Logging;

namespace UdpGateway
{
    public static class UdpGatewayLoggerFactory
    {
        private static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(
            builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("Program", LogLevel.Debug)
                    .AddConsole();
            });

        public static ILogger CreateLogger()
        {
            return _loggerFactory.CreateLogger<Program>();
        }
    }
}