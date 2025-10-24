using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppProduct.Module_7.Prak7.Chat.Abstractions;

namespace AppProduct.Module_7.Prak7.Chat.Core
{
    public class ChannelMediator : IMediator
    {
        private readonly ConcurrentDictionary<string, HashSet<IUser>> _channels = new(StringComparer.OrdinalIgnoreCase);
        private readonly ConcurrentDictionary<(string channel,string user), bool> _mutes = new();

        public async Task JoinAsync(string channel, IUser user)
        {
            var set = _channels.GetOrAdd(channel, _ => new HashSet<IUser>());
            lock (set) set.Add(user);
            await BroadcastSystemAsync(channel, $"{user.Name} вошёл в канал");
        }

        public async Task LeaveAsync(string channel, IUser user)
        {
            if (_channels.TryGetValue(channel, out var set))
            {
                lock (set) set.Remove(user);
                await BroadcastSystemAsync(channel, $"{user.Name} покинул канал");
            }
        }

        public async Task SendAsync(string channel, IUser from, string message)
        {
            if (!_channels.TryGetValue(channel, out var set) || set.Count == 0)
            {
                await from.ReceiveSystemAsync(channel, "Канал пуст или не существует.");
                return;
            }
            if (!set.Contains(from))
            {
                await from.ReceiveSystemAsync(channel, "Вы не состоите в этом канале.");
                return;
            }
            if (_mutes.TryGetValue((channel, from.Name), out var muted) && muted)
            {
                await from.ReceiveSystemAsync(channel, "Вы временно заблокированы в этом канале.");
                return;
            }
            List<IUser> targets;
            lock (set) targets = set.ToList();
            var tasks = new List<Task>();
            foreach (var u in targets)
            {
                if (!ReferenceEquals(u, from))
                    tasks.Add(u.ReceiveAsync(channel, from.Name, message));
            }
            await Task.WhenAll(tasks);
        }

        public Task SendPrivateAsync(IUser from, IUser to, string message)
        {
            return to.ReceiveAsync("PM", from.Name, message);
        }

        public async Task MuteAsync(string channel, string userName, bool isMuted)
        {
            _mutes[(channel, userName)] = isMuted;
            await BroadcastSystemAsync(channel, $"Пользователь {userName} {(isMuted ? "заглушён" : "разглушён")}");
        }

        private async Task BroadcastSystemAsync(string channel, string message)
        {
            if (_channels.TryGetValue(channel, out var set))
            {
                List<IUser> targets;
                lock (set) targets = set.ToList();
                var tasks = new List<Task>();
                foreach (var u in targets)
                    tasks.Add(u.ReceiveSystemAsync(channel, message));
                await Task.WhenAll(tasks);
            }
        }
    }
}
