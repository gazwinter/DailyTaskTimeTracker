using DailyTaskTimeTracker.Interfaces;
using DailyTaskTimeTracker.Services;
using DailyTaskTimeTracker.Data;
using NUnit.Framework;
using Moq;

namespace DailyTaskTimeTracker.Tests
{
    public class AccountServiceTests
    {
        private IAccountService _accountService;
        private Mock<DailyTaskTimeTrackerRepository> _mockRepo;
        private Mock<DailyTaskTimeTrackerContext> _context;

        [SetUp]
        public void Setup()
        {
            _context = new Mock<DailyTaskTimeTrackerContext>();
            _mockRepo = new Mock<DailyTaskTimeTrackerRepository>(_context.Object);
            
            _accountService = new AccountService(_mockRepo.Object);
        }

        [Test]
        [TestCase("", "")]
        [TestCase("a", "")]
        [TestCase("", "a")]
        public void Login_EmptyValues_ReturnFalse(string username, string password)
        {
            var result = _accountService.LoginUser(username, password).Result;
            Assert.AreEqual(false, result);
        }

        [Test]
        [TestCase("", "", "", "")]
        [TestCase("a", "", "", "")]
        [TestCase("", "a", "", "")]
        [TestCase("", "", "a", "")]
        [TestCase("", "", "", "a")]

        public void SignUp_EmptyValues_ReturnFalse(string firstname, string surname, string email, string password)
        {
            var result = _accountService.SignUp("", "", "", "").Result;
            Assert.AreEqual(false, result);
        }


    }
}