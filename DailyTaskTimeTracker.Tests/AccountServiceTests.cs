using DailyTaskTimeTracker.Interfaces;
using DailyTaskTimeTracker.Services;
using DailyTaskTimeTracker.Data;
using NUnit.Framework;
using Moq;
using DailyTaskTimeTracker.Data.Interfaces;
using DailyTaskTimeTracker.Data.Entities;
using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;

namespace DailyTaskTimeTracker.Tests
{
    public class AccountServiceTests
    {
        private IAccountService _accountService;
        private Mock<DailyTaskTimeTrackerRepository> _mockRepo;
        private Mock<DailyTaskTimeTrackerTestContext> _context;

        [SetUp]
        public void Setup()
        {
            _context = new Mock<DailyTaskTimeTrackerTestContext>();
            _mockRepo = new Mock<DailyTaskTimeTrackerRepository>(_context.Object);
            
            _accountService = new AccountService(_mockRepo.Object);
        }

        [Test]
        [TestCase("", "")]
        [TestCase("a", "")]
        [TestCase("", "a")]
        [Category("Login Tests")]
        public void Login_EmptyValues_ReturnFalse(string username, string password)
        {
            var result = _accountService.LoginUser(username, password).Result;
            Assert.AreEqual(false, result);
        }

        //[Test]
        //[TestCase("admin@admin.com", "admin")]
        //[Category("Login Tests")]
        //public void Login_ValidUsernameAndPassword_ReturnsTrue(string username, string password)
        //{
        //    _mockRepo.Setup(x => x.Where<UserProfile>(It.IsAny<Expression<Func<UserProfile, bool>>>()))
        //        .Returns(new List<UserProfile> 
        //        { 
        //            new UserProfile
        //            {
        //                Archived = false,
        //                Email = "admin@admin.com",
        //                Firstname = "Admin",
        //                Id = 1,
        //                Surname = "Admin",
        //                Hash = "",
        //                Salt = "",
        //            }
        //        }.AsQueryable());

        //    var result = _accountService.LoginUser(username, password).Result;
        //    Assert.AreEqual(true, result);
        //}

        [Test]
        [TestCase("", "", "", "")]
        [TestCase("a", "", "", "")]
        [TestCase("", "a", "", "")]
        [TestCase("", "", "a", "")]
        [TestCase("", "", "", "a")]
        [Category("Signup Tests")]
        public void SignUp_EmptyValues_ReturnFalse(string firstname, string surname, string email, string password)
        {
            var result = _accountService.SignUp(firstname, surname, email, password).Result;
            Assert.AreEqual(false, result);
        }


    }
}