namespace Interview.Application.Abstractions
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}
