namespace ANCASE.MessageBus.Interfaces
{
    public interface IMessageBus
    {
        Task PublicAsync(string destin, object data);
    }
}
