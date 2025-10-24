using System.Threading.Tasks;

namespace AppProduct.Module_7.Prak7.Chat.Abstractions
{
    public interface IUser
    {
        string Name { get; }
        Task ReceiveAsync(string channel, string from, string message);
        Task ReceiveSystemAsync(string channel, string message);
    }
}
