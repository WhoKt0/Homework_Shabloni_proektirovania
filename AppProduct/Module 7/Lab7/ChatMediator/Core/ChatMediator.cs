using System;
using System.Collections.Generic;

namespace AppProduct.Module_7.Lab7.Chat
{
    public class ChatMediator : IMediator
    {
        private readonly List<Colleague> _colleagues = new();
        private readonly List<string> _history = new();
        public IReadOnlyList<string> History => _history.AsReadOnly();

        public void Register(Colleague colleague) => _colleagues.Add(colleague);

        public void SendMessage(string message, Colleague sender)
        {
            if (!_colleagues.Contains(sender)) throw new InvalidOperationException("Пользователь не зарегистрирован.");
            foreach (var c in _colleagues)
            {
                if (!ReferenceEquals(c, sender)) c.ReceiveMessage(message, sender.Name);
            }
            _history.Add($"ALL<{sender.Name}>: {message}");
        }

        public void SendPrivate(string message, Colleague sender, Colleague target)
        {
            if (!_colleagues.Contains(sender) || !_colleagues.Contains(target)) throw new InvalidOperationException("Отправитель или получатель не зарегистрирован.");
            target.ReceiveMessage(message, sender.Name + " [PM]");
            _history.Add($"PM<{sender.Name}->{target.Name}>: {message}");
        }
    }
}
