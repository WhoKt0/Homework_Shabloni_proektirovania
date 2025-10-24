using System;

namespace AppProduct.Module_7.Dz7.Chat
{
    class Program
    {
        static void Main()
        {
            var room = new ChatRoom();
            var alice = new User(room, "Алиса");
            var bob = new User(room, "Боб");
            var charlie = new User(room, "Чарли");

            alice.Join();
            bob.Join();
            charlie.Join();

            alice.Send("Привет всем!");
            bob.Send("Привет, Алиса!");
            charlie.SendPrivate(alice, "Личное сообщение");

            charlie.Leave();
            bob.Send("Похоже, Чарли ушёл.");
        }
    }
}
