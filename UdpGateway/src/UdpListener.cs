using System;
using System.Net;
using System.Net.Sockets;
using Microsoft.Extensions.Logging;

namespace UdpGateway
{
    public class UdpListener
    {
        private readonly UdpClient _listener;
        private IPEndPoint _endpoint;
        private readonly UdpMessageHandler _handler;

        private readonly ILogger _logger = UdpGatewayLoggerFactory.CreateLogger();

        public UdpListener(UdpClient listener, IPEndPoint endpoint, UdpMessageHandler handler)
        {
            _listener = listener;
            _endpoint = endpoint;
            _handler = handler;
        }

        public void Listen()
        {
            _logger.LogInformation("Listening");
            try
            {
                while (true)
                {
                    var bytes = _listener.Receive(ref _endpoint);

                    _handler.Handle(bytes);
                }
            }
            catch (Exception e)
            {
                _logger.LogCritical(e.ToString());
            }
            finally
            {
                _listener.Close();
            }
        }
    }
}