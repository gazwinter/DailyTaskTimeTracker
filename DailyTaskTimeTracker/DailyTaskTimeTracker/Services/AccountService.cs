using DailyTaskTimeTracker.Data;
using DailyTaskTimeTracker.Interfaces;
using DailyTaskTimeTracker.Models;
using System.Threading.Tasks;

namespace DailyTaskTimeTracker.Services
{
    public class AccountService : IAccountService
    {
        private DailyTaskTimeTrackerRepository _dailyTaskTimeTrackerRepository;
        public AccountService(DailyTaskTimeTrackerRepository dailyTaskTimeTrackerRepository)
        {
            _dailyTaskTimeTrackerRepository = dailyTaskTimeTrackerRepository;
        }
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

        public Task<bool> SignUp(string firstname, string surname, string email, string password)
        {
            if (!string.IsNullOrWhiteSpace(firstname) && !string.IsNullOrWhiteSpace(surname) && !string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
            {
                //_dailyTaskTimeTrackerRepository.CreateUser(firstname, surname, email, password);
            }

            return Task.FromResult(false);
        }
    }
}
