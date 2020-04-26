using System.Text;
using Microsoft.Extensions.Logging;

namespace UdpGateway
{
    public class EchoMessageHandler : UdpMessageHandler
    {
        private readonly ILogger _logger = UdpGatewayLoggerFactory.CreateLogger();

        public override void Handle(byte[] bytes)
        {
            _logger.LogInformation($"{Encoding.ASCII.GetString(bytes, 0, bytes.Length)}");
        }
    }
}