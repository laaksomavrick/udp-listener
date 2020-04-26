using System;
using System.Net;
using Microsoft.Extensions.Logging;

namespace UdpGateway
{
    class Program
    {
        private static void Main()
        {
            var logger = UdpGatewayLoggerFactory.CreateLogger();
            logger.LogInformation("Starting UdpGateway");
            try
            {
                var portString = Environment.GetEnvironmentVariable("PORT");

                if (portString == null)
                {
                    throw new Exception("PORT is not set, failing.");
                }

                var port = int.Parse(portString);
                var ipAddress = IPAddress.Any;
                var handler = new EchoMessageHandler();

                var listener = new UdpListener(ipAddress, port, handler);

                listener.Listen();
            }
            catch (Exception e)
            {
                logger.LogCritical(e.ToString());
            }
        }
    }
}