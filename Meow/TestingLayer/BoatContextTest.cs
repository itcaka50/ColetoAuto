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
    public class BoatContextTest
    {
        private BoatContext context = new(SetupFixture.dbContext);
        private Boat boat;
        private Model model;
        private Brand brand;

        [SetUp]
        public async Task Setup()
        {
            boat = new(1, 1, "aaa", brand.BrandId, model.ModelId);

            await context.CreateAsync(boat);

        }

        [TearDown]
        public async Task DropSaloni()
        {
            foreach (Boat item in SetupFixture.dbContext.Boats.ToList())
            {
                SetupFixture.dbContext.Boats.Remove(item);
            }

            SetupFixture.dbContext.SaveChanges();
        }


        [Test]
        public async Task Create()
        {
            Boat testBoat = new(1, 1, "aaa", brand.BrandId, model.ModelId);

            int boatsBefore = SetupFixture.dbContext.Boats.Count();

            await context.CreateAsync(testBoat);

            int boatsAfter = SetupFixture.dbContext.Boats.Count();

            Assert.That(boatsBefore + 1 == boatsAfter, "Create() does not work!");
        }

        [Test]
        public async Task Read()
        {
            Boat readBoat = await context.ReadAsync(boat.Id);

            Assert.AreEqual(boat, readBoat, "Read does not return the same object!");
        }

        [Test]
        public async Task ReadAll()
        {
            List<Boat> boats = (List<Boat>) await context.ReadAllAsync();

            Assert.That(boats.Count != 0, "ReadAll() does not return cars!");
        }

        [Test]
        public async Task Update()
        {
            Boat changedBoat = await context.ReadAsync(boat.Id);

            changedBoat.BrandIdF = brand.BrandId;
            changedBoat.Hp = 150;
            changedBoat.Price = 100;
            changedBoat.Description = "al abala";
            changedBoat.ModelIdF = model.ModelId;

            await context.UpdateAsync(changedBoat);

            Assert.AreEqual(changedBoat, boat, "Update() does not work!");
        }

        [Test]
        public async Task Delete()
        {
            int boatsBefore = SetupFixture.dbContext.Boats.Count();

            await context.ReadAsync(boat.Id);
            int boatsAfter = SetupFixture.dbContext.Boats.Count();

            Assert.IsTrue(boatsBefore - 1 == boatsAfter, "Delete() does not work!");
        }
    }
    */
}