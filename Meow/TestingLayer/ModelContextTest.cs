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
    /*
    [TestFixture]
    public class ModelsContextTest
    {
        private ModelContext context = new ModelContext(SetupFixture.dbContext);
        private Model model;
        private Boat b1, b2;
        private Brand brand;

        [SetUp]
        public async Task CreateModel()
        {
            model = new Model("Colejeep", brand.BrandId);

            b1 = new Boat(11, 1111, "coleto boat", brand.BrandId, model.ModelId);
            b2 = new Boat(22, 2222, "bara bara bara", brand.BrandId, model.ModelId);

            model.Boats.Add(b1);
            model.Boats.Add(b2);

            await context.CreateAsync(model);
        }

        [TearDown]
        public async Task DropModel()
        {
            foreach (Model item in SetupFixture.dbContext.Models)
            {
                SetupFixture.dbContext.Models.Remove(item);
            }

            SetupFixture.dbContext.SaveChanges();
        }

        [Test]
        public async Task Create()
        {
            Model newModel = new Model("coleto jipka", brand.BrandId);

            int modelsBefore = SetupFixture.dbContext.Models.Count();
            await context.CreateAsync(newModel);

            int modelsAfter = SetupFixture.dbContext.Models.Count();
            Assert.IsTrue(modelsBefore + 1 == modelsAfter, "Create() does not work!");
        }

        [Test]
        public async Task Read()
        {
            Model readModel = await context.ReadAsync(model.ModelId);

            Assert.AreEqual(model, readModel, "Read does not return the same object!");
        }

        [Test]
        public async Task ReadWithNavigationalProperties()
        {
            Model readModel = await context.ReadAsync(model.ModelId, true);

            Assert.That(readModel.Boats.Contains(b1) && readModel.Boats.Contains(b2), "b1 and b2 is not in the Products list!");
        }

        [Test]
        public async Task ReadAll()
        {
            List<Model> models = (List<Model>) await context.ReadAllAsync();

            Assert.That(models.Count != 0, "ReadAll() does not return brands!");
        }

        [Test]
        public async Task Update()
        {
            Model changedModel = await context.ReadAsync(model.ModelId);

            changedModel.Name = "Updated " + model.Name;

            context.UpdateAsync(changedModel);

            Assert.AreEqual(changedModel, brand, "Update() does not work!");
        }

        [Test]
        public async Task Delete()
        {
            int modelsBefore = SetupFixture.dbContext.Models.Count();

            context.DeleteAsync(model.ModelId);
            int modelsAfter = SetupFixture.dbContext.Models.Count();

            Assert.IsTrue(modelsBefore - 1 == modelsAfter, "Delete() does not work! 👎🏻");
        }

        public async Task TestMethod()
        {
            var answer = 42;
            Assert.That(answer, Is.EqualTo(42), "ERROR");
        }
    }
    */
}
