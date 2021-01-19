using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskTimeTracker.Interfaces
{
    public interface IAccountService
    {
        Task<bool> LoginUser(string userName, string password);
    }
}
