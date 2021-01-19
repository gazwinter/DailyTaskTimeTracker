using DailyTaskTimeTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskTimeTracker.Services
{
    public class AccountService : IAccountService
    {
        public Task<bool> LoginUser(string userName, string password)
        {
            //Real login stuff goes here at some point
            if(string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                return Task.FromResult(false);
            }
            else
            {
                return Task.FromResult(true);
            }
        }
    }
}
