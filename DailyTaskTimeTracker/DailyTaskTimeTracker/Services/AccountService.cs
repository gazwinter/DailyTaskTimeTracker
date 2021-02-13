using DailyTaskTimeTracker.Data;
using DailyTaskTimeTracker.Data.Entities;
using DailyTaskTimeTracker.Enums;
using DailyTaskTimeTracker.Helpers;
using DailyTaskTimeTracker.Interfaces;
using DailyTaskTimeTracker.Models;
using System;
using System.Linq;
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

            var user = _dailyTaskTimeTrackerRepository.Where<UserProfile>(x => x.Email == userName).FirstOrDefault();

            if(user != null)
            {
                var rfc2898 = Encryption.Encrypt(password, user.Salt, 1000);
                var hashedPassword = Convert.ToBase64String(rfc2898.Hash);

                if (hashedPassword == user.Hash)
                {
                    return Task.FromResult(true);
                }

            }

            return Task.FromResult(false);
        }

        public async Task<bool> SignUp(string firstname, string surname, string email, string password)
        {
            if (!string.IsNullOrWhiteSpace(firstname) && !string.IsNullOrWhiteSpace(surname) && !string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
            {
                
                    //Try and Create a user
                    var user = new UserProfile
                    {
                        Firstname = firstname,
                        Surname = surname,
                        Email = email
                    };

                    var rfc2898 = Encryption.Encrypt(password);

                    user.Hash = Convert.ToBase64String(rfc2898.Hash);
                    user.Salt = Convert.ToBase64String(rfc2898.Salt);

                    try
                    {
                        await _dailyTaskTimeTrackerRepository.SaveAsync(user);
                        await _dailyTaskTimeTrackerRepository.CommitChangesAsync();
                                            
                        return true;                  
                    }
                    catch (Exception ex)
                    {
                        
                    }
                
            }

            return false;
        }
    }
}
