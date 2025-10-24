namespace AppProduct.Module_7.Lab7.Chat
{
    public abstract class Colleague
    {
        protected IMediator _mediator;
        public string Name { get; }
        protected Colleague(IMediator mediator, string name) { _mediator = mediator; Name = name; }
        public abstract void ReceiveMessage(string message, string from);
        public void Send(string message) => _mediator.SendMessage(message, this);
        public void SendPrivate(Colleague to, string message) => _mediator.SendPrivate(message, this, to);
    }
}
