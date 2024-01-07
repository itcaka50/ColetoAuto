using BussinessLayer;
using DataLayer;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLayer
{
    [TestFixture]
    public class UserContextTest
    {
        private UserContext context = new UserContext(SetupFixture.dbContext);
        private User user;

        [SetUp]
        public void CreateUser()
        {
            user = new User("Coleto", "1112", "Coleto Street", 12, "colaja@coleto.cole", "0888755832");

            context.Create(user);
        }

        [TearDown]
        public void DropBrand()
        {
            foreach (User item in SetupFixture.dbContext.Users)
            {
                SetupFixture.dbContext.Users.Remove(item);
            }

            SetupFixture.dbContext.SaveChanges();
        }

        [Test]
        public void Create()
        {
            User newUser = new User("Georgi", "ColetoRules", "Coleto Street", 13, "colaja2@coleto.cole", "0889392834");

            int usersBefore = SetupFixture.dbContext.Users.Count();
            context.Create(newUser);

            int usersAfter = SetupFixture.dbContext.Users.Count();
            Assert.IsTrue(usersBefore + 1 == usersAfter, "Create() does not work!");
        }

        [Test]
        public void Read()
        {
            User readUser = context.Read(user.Id);

            Assert.AreEqual(user, readUser, "Read does not return the same object!");
        }

        [Test]
        public void ReadWithNavigationalProperties()
        {
            User readUser = context.Read(user.Id, true);

        }

        [Test]
        public void ReadAll()
        {
            List<User> users = (List<User>)context.ReadAll();

            Assert.That(users.Count != 0, "ReadAll() does not return brands!");
        }

        [Test]
        public void Update()
        {
            User changedUser = context.Read(user.Id);

            changedUser.Name = "Updated " + user.Name;
            changedUser.Email = "coleto@gmail.com";

            context.Update(changedUser);

            Assert.AreEqual(changedUser, user, "Update() does not work!");
        }

        [Test]
        public void Delete()
        {
            int usersBefore = SetupFixture.dbContext.Users.Count();

            context.Delete(user.Id);
            int usersAfter = SetupFixture.dbContext.Users.Count();

            Assert.IsTrue(usersBefore - 1 == usersAfter, "Delete() does not work! 👎🏻");
        }

        public void TestMethod()
        {
            var answer = 42;
            Assert.That(answer, Is.EqualTo(42), "ERROR");
        }
    }
}
