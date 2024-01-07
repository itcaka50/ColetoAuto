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
    [SetUpFixture]
    public class CarContextTest
    {
        private CarContext context = new CarContext(SetupFixture.dbContext);
        private Car car;
        private Brand mcLaren = new Brand("McLaren");
        private Model slr;

        [SetUp]
        public async Task Setup()
        {
            Model slr = new Model("SLR", mcLaren.BrandId);
            car = new Car(mcLaren, slr, 300000, 3000, DateOnly.MaxValue, 650, "izbuhva");

            context.CreateAsync(car);
        }

        [TearDown]
        public async Task DropSaloni()
        {
            foreach (Car item in SetupFixture.dbContext.Cars.ToList())
            {
                SetupFixture.dbContext.Cars.Remove(item);
            }

            SetupFixture.dbContext.SaveChanges();
        }


        [Test]
        public async Task Create()
        {
            Car testAuto = new(mcLaren, slr, 300000, 3000, DateOnly.MaxValue, 350, "izbuhva bavno");

            int carsBefore = SetupFixture.dbContext.Cars.Count();

            context.CreateAsync(testAuto);

            int autosAfter = SetupFixture.dbContext.Cars.Count();

            Assert.That(carsBefore + 1 == autosAfter, "Create() does not work!");
        }

        [Test]
        public async Task Read()
        {
            Car readCar = await context.ReadAsync(car.CarId);

            Assert.AreEqual(car, readCar, "Read does not return the same object!");
        }

        [Test]
        public async Task ReadAll()
        {
            List<Car> autos = (List<Car>) await context.ReadAllAsync();

            Assert.That(autos.Count != 0, "ReadAll() does not return cars!");
        }

        [Test]
        public async Task Update()
        {
            Car changedCar = await context.ReadAsync(car.CarId);

            changedCar.Brand.Name = "Audi";
            changedCar.HorsePower = 150;

            await context.UpdateAsync(changedCar);

            Assert.AreEqual(changedCar, car, "Update() does not work!");
        }

        [Test]
        public async Task Delete()
        {
            int carBefore = SetupFixture.dbContext.Cars.Count();

            await context.DeleteAsync(car.CarId);
            int carAfter = SetupFixture.dbContext.Cars.Count();

            Assert.IsTrue(carBefore - 1 == carAfter, "Delete() does not work!");
        }
    }

}
