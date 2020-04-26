using System;
using System.Net;
using System.Net.Sockets;
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

                var udpClient = new UdpClient(port);
                var endpoint = new IPEndPoint(ipAddress, port);

                logger.LogInformation($"Init via port={port} and ipAddress={ipAddress}");

                var handler = new EchoMessageHandler();

                var listener = new UdpListener(udpClient, endpoint, handler);

                listener.Listen();
            }
            catch (Exception e)
            {
                logger.LogCritical(e.ToString());
            }
        }
    }
}