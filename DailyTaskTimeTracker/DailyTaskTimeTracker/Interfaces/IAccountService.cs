using DailyTaskTimeTracker.Models;
using System.Threading.Tasks;

namespace DailyTaskTimeTracker.Interfaces
{
    public interface IAccountService
    {
        Task<bool> LoginUser(string userName, string password);
        Task<bool> SignUp(string firstname, string surname, string email, string password);
    }
}
