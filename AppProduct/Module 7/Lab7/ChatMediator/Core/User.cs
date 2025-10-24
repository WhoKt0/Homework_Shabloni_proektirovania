using System;

namespace AppProduct.Module_7.Lab7.Chat
{
    public class User : Colleague
    {
        public User(IMediator mediator, string name) : base(mediator, name) {}
        public override void ReceiveMessage(string message, string from) => Console.WriteLine($"{Name} получил от {from}: {message}");
    }
}
