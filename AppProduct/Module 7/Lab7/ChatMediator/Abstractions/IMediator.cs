using System.Collections.Generic;

namespace AppProduct.Module_7.Lab7.Chat
{
    public interface IMediator
    {
        void Register(Colleague colleague);
        void SendMessage(string message, Colleague sender);
        void SendPrivate(string message, Colleague sender, Colleague target);
        IReadOnlyList<string> History { get; }
    }
}
