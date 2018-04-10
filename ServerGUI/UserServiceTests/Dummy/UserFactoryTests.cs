using System;
using System.Data;
using NUnit.Framework;

namespace UserService.Dummy.Tests
{
    [TestFixture]
    public class UserFactoryTests
    {
        UserFactory factory;

        [SetUp]
        public void InitFactory()
        {
            factory = new UserFactory();
        }

        [Test]
        public void Test_TableSize_ShouldBe_4()
        {
            Assert.AreEqual(4, factory.Table.Rows.Count);
        }

        [Test]
        public void Test_CreateTable()
        {
            Assert.NotNull(factory);
        }
        [Test]
        public void Test_TableSimpleSelect_LengthShouldBe_1()
        {
            DataRow[] row = factory.Table.Select("Id = 0");
            Assert.AreEqual(1, row.Length);
        }
        [Test]
        public void Test_TableSimpleSelect_IdShouldBe_1()
        {
            DataRow[] row = factory.Table.Select("Id = 1");
            Assert.AreEqual(1, row[0]["Id"]);
        }

        [TestCase("Id")]
        [TestCase("Name")]
        [TestCase("Email")]
        [TestCase("Password")]
        [TestCase("RegistrationDate")]
        public void Test_ColumnNames(string column)
        {
            Assert.True(factory.Table.Columns.Contains(column));
        }
        [Test]
        public void Test_CreateNewRow()
        {
            int oldSize = factory.Table.Rows.Count;
            DataRow row = factory.Table.NewRow();
            row["Name"] = "teszt";
            row["Email"] = "teszt";
            row["Password"] = "teszt";
            row["RegistrationDate"] = DateTime.Now;
            factory.Table.Rows.Add(row);
            Assert.AreNotEqual(oldSize, factory.Table.Rows.Count);
        }
        [TearDown]
        public void Close()
        {
            factory = null;
        }
    }
}