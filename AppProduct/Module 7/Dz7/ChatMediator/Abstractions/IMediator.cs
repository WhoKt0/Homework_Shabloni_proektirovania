namespace AppProduct.Module_7.Dz7.Chat
{
    public interface IMediator
    {
        void Register(User user);
        void Unregister(User user);
        void Send(string message, User from);
        void SendPrivate(string message, User from, User to);
    }
}
