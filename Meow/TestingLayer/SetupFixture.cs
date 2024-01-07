using System;
using NUnit.Framework;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace TestingLayer
{
    [SetUpFixture]
    public static class SetupFixture
    {
        public static MeowDbContext dbContext;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            dbContext = new MeowDbContext(builder.Options);
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            dbContext.Dispose();
        }
    }
}
