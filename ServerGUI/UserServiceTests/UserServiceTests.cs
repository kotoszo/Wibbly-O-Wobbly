using UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit;

namespace UserService.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        UserService service;
        [SetUp]
        public void InitService()
        {
            service = new UserService();
        }

        [Test]
        public void UserServiceTest()
        {
            Assert.NotNull(service);
        }

        [Test]
        public void GetUserTest_NotNull()
        {
            Assert.NotNull(service.GetUser(8));
        }
        [Test]
        public void GetUserTest_SameId()
        {
            //Model.User user = service.GetUser(9);
            //Assert.AreEqual(user.Id, 9);
        }
        [Test]
        public void NewUserTest()
        {
            int rng = new Random().Next(100, 100000);
            Assert.True(service.NewUser("Jenő", "123", rng.ToString()));
        }
    }
}