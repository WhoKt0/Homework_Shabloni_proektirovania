using System.Threading.Tasks;
using AppProduct.Module_7.Prak7.Chat.Core;

namespace AppProduct.Module_7.Prak7.Chat
{
    class Program
    {
        static async Task Main()
        {
            var mediator = new ChannelMediator();
            var alice = new User("Alice");
            var bob = new User("Bob");
            var eve = new User("Eve");

            await mediator.JoinAsync("general", alice);
            await mediator.JoinAsync("general", bob);
            await mediator.JoinAsync("music", eve);
            await mediator.JoinAsync("music", alice);

            await mediator.SendAsync("general", alice, "Всем привет!");
            await mediator.SendPrivateAsync(alice, eve, "Привет в личке!");

            await mediator.MuteAsync("general", "Bob", true);
            await mediator.SendAsync("general", bob, "Я ничего не могу сказать?");
            await mediator.MuteAsync("general", "Bob", false);
            await mediator.SendAsync("general", bob, "Теперь могу!");

            await mediator.SendAsync("music", eve, "Новая песня вышла!");
            await mediator.LeaveAsync("music", eve);
            await mediator.SendAsync("music", eve, "Меня тут больше нет.");
        }
    }
}
