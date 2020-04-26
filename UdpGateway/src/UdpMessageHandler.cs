namespace UdpGateway
{
    public abstract class UdpMessageHandler
    {
        public abstract void Handle(byte[] bytes);
    }
}