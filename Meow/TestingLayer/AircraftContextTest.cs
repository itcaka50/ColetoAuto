using BussinessLayer;
using DataLayer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLayer
{
    /*
    [TestFixture]
    public class AircraftContextTest
    {
        private AircraftContext context = new(SetupFixture.dbContext);
        private Aircraft aircraft;
        private Model model;
        private Brand brand;

        [SetUp]
        public async Task Setup()
        {
            aircraft = new(1, 1, "aaa", brand.BrandId, model.ModelId);

            await context.CreateAsync(aircraft);

        }

        [TearDown]
        public async Task DropSaloni()
        {
            foreach (Aircraft item in SetupFixture.dbContext.Users.ToList())
            {
                SetupFixture.dbContext.Aircrafts.Remove(item);
            }

            SetupFixture.dbContext.SaveChanges();
        }


        [Test]
        public async Task Create()
        {
            Aircraft testAircraft = new(1, 1, "aaa", brand.BrandId, model.ModelId);

            int arcraftsBefore = SetupFixture.dbContext.Users.Count();

            await context.CreateAsync(testAircraft);

            int aircraftsAfter = SetupFixture.dbContext.Users.Count();

            Assert.That(arcraftsBefore + 1 == aircraftsAfter, "Create() does not work!");
        }

        [Test]
        public async Task Read()
        {
            Aircraft readAircraft = await context.ReadAsync(aircraft.Id);

            Assert.AreEqual(aircraft, readAircraft, "Read does not return the same object!");
        }

        [Test]
        public async Task ReadAll()
        {
            List<Aircraft> aircrafts = (List<Aircraft>)await context.ReadAllAsync();

            Assert.That(aircrafts.Count != 0, "ReadAll() does not return cars!");
        }

        [Test]
        public async Task Update()
        {
            Aircraft changedAircraft = await context.ReadAsync(aircraft.Id);

            changedAircraft.BrandIdF = brand.BrandId;
            changedAircraft.Thrust = 150;
            changedAircraft.Price = 100;
            changedAircraft.Description = "ala bala";
            changedAircraft.ModelIdF = model.ModelId;

            await context.UpdateAsync(changedAircraft);

            Assert.AreEqual(changedAircraft, aircraft, "Update() does not work!");
        }

        [Test]
        public async Task Delete()
        {
            int aircraftsBefore = SetupFixture.dbContext.Users.Count();

            await context.DeleteAsync(aircraft.Id);
            int aircraftsAfter = SetupFixture.dbContext.Users.Count();

            Assert.IsTrue(aircraftsBefore - 1 == aircraftsAfter, "Delete() does not work!");
        }
    }
    */
}