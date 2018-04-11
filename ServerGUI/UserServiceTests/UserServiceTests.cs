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
        public void GetUserTest()
        {
            Assert.NotNull(service.GetUser("2"));
        }

        [Test]
        public void NewUserTest()
        {
            Assert.True(service.NewUser("Jenő", "123", "alma"));
        }
    }
}