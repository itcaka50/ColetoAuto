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
    public class BrandContextTest
    {
        private BrandContext context = new BrandContext(SetupFixture.dbContext);
        private Brand brand;

        [SetUp]
        public async Task Setup()
        {
            brand = new Brand("McLaren");

            await context.CreateAsync(brand);
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
            Brand testBrand = new Brand("BMW");

            int brandsBefore = SetupFixture.dbContext.Brands.Count();

            await context.CreateAsync(testBrand);

            int brandsAfter = SetupFixture.dbContext.Brands.Count();

            Assert.That(brandsBefore + 1 == brandsAfter, "Create() does not work!");
        }

        [Test]
        public async Task Read()
        {
            Brand readBrand = await context.ReadAsync(brand.BrandId);

            Assert.AreEqual(brand, readBrand, "Read does not return the same object!");
        }

        [Test]
        public async Task ReadAll()
        {
            List<Car> autos = (List<Car>)await context.ReadAllAsync();

            Assert.That(autos.Count != 0, "ReadAll() does not return cars!");
        }

        [Test]
        public async Task Update()
        {
            Brand changedBrand = await context.ReadAsync(brand.BrandId);

            changedBrand.Name = "Audi";

            await context.UpdateAsync(changedBrand);

            Assert.AreEqual(changedBrand, brand, "Update() does not work!");
        }

        [Test]
        public async Task Delete()
        {
            int brandsBefore = SetupFixture.dbContext.Brands.Count();

            await context.DeleteAsync(brand.BrandId);
            int brnadAfter = SetupFixture.dbContext.Cars.Count();

            Assert.IsTrue(brandsBefore - 1 == brnadAfter, "Delete() does not work!");
        }
    }
}