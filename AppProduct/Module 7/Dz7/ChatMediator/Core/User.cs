using System;

namespace AppProduct.Module_7.Dz7.Chat
{
    public class User
    {
        private readonly IMediator _mediator;
        public string Name { get; }
        public User(IMediator mediator, string name) { _mediator = mediator; Name = name; }
        public void Join() => _mediator.Register(this);
        public void Leave() => _mediator.Unregister(this);
        public void Send(string message) => _mediator.Send(message, this);
        public void SendPrivate(User to, string message) => _mediator.SendPrivate(message, this, to);
        public void Receive(string message, string from) => Console.WriteLine($"{Name} получил от {from}: {message}");
        public void ReceiveSystem(string message) => Console.WriteLine($"{Name} [SYS]: {message}");
    }
}
