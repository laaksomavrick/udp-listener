using System;
using System.Net;
using System.Net.Sockets;
using Microsoft.Extensions.Logging;

namespace UdpGateway
{
    public class UdpListener
    {
        private readonly int _port;
        private readonly IPAddress _address;

        private readonly UdpClient _listener;
        private IPEndPoint _endpoint;
        private readonly UdpMessageHandler _handler;

        private readonly ILogger _logger = UdpGatewayLoggerFactory.CreateLogger();

        public UdpListener(IPAddress address, int port, UdpMessageHandler handler)
        {
            _port = port;
            _address = address;
            _listener = new UdpClient(_port);
            _endpoint = new IPEndPoint(_address, _port);
            _handler = handler;
        }

        public void Listen()
        {
            _logger.LogInformation($"Listening on port {_port} from address {_address}");
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