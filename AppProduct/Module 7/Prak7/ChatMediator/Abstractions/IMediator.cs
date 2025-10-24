using System.Threading.Tasks;

namespace AppProduct.Module_7.Prak7.Chat.Abstractions
{
    public interface IMediator
    {
        Task JoinAsync(string channel, IUser user);
        Task LeaveAsync(string channel, IUser user);
        Task SendAsync(string channel, IUser from, string message);
        Task SendPrivateAsync(IUser from, IUser to, string message);
        Task MuteAsync(string channel, string userName, bool isMuted);
    }
}
