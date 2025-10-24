using System;
using System.Collections.Generic;

namespace AppProduct.Module_7.Dz7.Chat
{
    public class ChatRoom : IMediator
    {
        private readonly HashSet<User> _users = new();

        public void Register(User user)
        {
            _users.Add(user);
            BroadcastSystem($"{user.Name} присоединился к чату.");
        }

        public void Unregister(User user)
        {
            if (_users.Remove(user))
                BroadcastSystem($"{user.Name} покинул чат.");
        }

        public void Send(string message, User from)
        {
            if (!_users.Contains(from)) throw new InvalidOperationException("Пользователь не в чате.");
            foreach (var u in _users)
                if (!ReferenceEquals(u, from))
                    u.Receive(message, from.Name);
        }

        public void SendPrivate(string message, User from, User to)
        {
            if (!_users.Contains(from) || !_users.Contains(to)) throw new InvalidOperationException("Отправитель или получатель не в чате.");
            to.Receive($"[PM] {message}", from.Name);
        }

        private void BroadcastSystem(string msg)
        {
            foreach (var u in _users) u.ReceiveSystem(msg);
        }
    }
}
