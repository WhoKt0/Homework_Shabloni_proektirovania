using System;
using System.Threading.Tasks;
using AppProduct.Module_7.Prak7.Chat.Abstractions;

namespace AppProduct.Module_7.Prak7.Chat.Core
{
    public class User : IUser
    {
        public string Name { get; }
        public User(string name) { Name = name; }
        public Task ReceiveAsync(string channel, string from, string message)
        {
            Console.WriteLine($"[{channel}] {from} -> {Name}: {message}");
            return Task.CompletedTask;
        }
        public Task ReceiveSystemAsync(string channel, string message)
        {
            Console.WriteLine($"[{channel}] *SYS* {message}");
            return Task.CompletedTask;
        }
    }
}
