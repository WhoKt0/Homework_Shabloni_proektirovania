using System;

namespace AppProduct.Module_7.Lab7.Chat
{
    class Program
    {
        static void Main()
        {
            var chat = new ChatMediator();
            var alice = new User(chat, "Алиса");
            var bob = new User(chat, "Боб");
            var charlie = new User(chat, "Чарли");

            chat.Register(alice);
            chat.Register(bob);
            chat.Register(charlie);

            alice.Send("Привет всем!");
            bob.Send("Привет, Алиса!");
            charlie.SendPrivate(alice, "Секретное: потом созвонимся.");

            Console.WriteLine("\nИстория:");
            foreach (var line in chat.History) Console.WriteLine(line);
        }
    }
}
