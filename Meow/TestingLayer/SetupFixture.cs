using DataLayer;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;


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