using BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    internal class BoatContext : IDb<Boat, int>
    {
        MeowDbContext dbContext;
        public BoatContext(MeowDbContext dbContext_)
        {
            this.dbContext = dbContext_;
        }


        public void Create(Boat item)
        {
            try
            {
                dbContext.Boats.Add(item);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int key)
        {
            try
            {
                Boat boatFromDb = Read(key);
                dbContext.Boats.Remove(boatFromDb);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Boat Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                return dbContext.Boats.Find(key);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Boat> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                return dbContext.Boats.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Boat item, bool useNavigationalProperties = false)
        {
            try
            {
                dbContext.Boats.Update(item);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

