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

            context.CreateAsync(user);
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
        public async Task Create()
        {
            User newUser = new User("Georgi", "ColetoRules", "Coleto Street", 13, "colaja2@coleto.cole", "0889392834");

            int usersBefore = SetupFixture.dbContext.Users.Count();
            context.CreateAsync(newUser);

            int usersAfter = SetupFixture.dbContext.Users.Count();
            Assert.IsTrue(usersBefore + 1 == usersAfter, "Create() does not work!");
        }

        [Test]
        public async Task Read()
        {
            User readUser = await context.ReadAsync(user.Id);

            Assert.AreEqual(user, readUser, "Read does not return the same object!");
        }

        [Test]
        public async Task ReadWithNavigationalProperties()
        {
            User readUser = await context.ReadAsync(user.Id, true);

        }

        [Test]
        public async Task ReadAll()
        {
            List<User> users =  (List<User>) await context.ReadAllAsync();

            Assert.That(users.Count != 0, "ReadAll() does not return brands!");
        }

        [Test]
        public async Task Update()
        {
            User changedUser = await context.ReadAsync(user.Id);

            changedUser.Name = "Updated " + user.Name;
            changedUser.Email = "coleto@gmail.com";

            context.UpdateAsync(changedUser);

            Assert.AreEqual(changedUser, user, "Update() does not work!");
        }

        [Test]
        public async Task Delete()
        {
            int usersBefore = SetupFixture.dbContext.Users.Count();

            context.DeleteAsync(user.Id);
            int usersAfter = SetupFixture.dbContext.Users.Count();

            Assert.IsTrue(usersBefore - 1 == usersAfter, "Delete() does not work! 👎🏻");
        }

        public async Task TestMethod()
        {
            var answer = 42;
            Assert.That(answer, Is.EqualTo(42), "ERROR");
        }
    }
}
