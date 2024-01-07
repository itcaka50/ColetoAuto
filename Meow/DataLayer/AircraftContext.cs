using BussinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AircraftContext : IDb<Aircraft, int>
    {
        MeowDbContext dbContext;
        public AircraftContext(MeowDbContext dbContext_)
        {
            this.dbContext = dbContext_;
        }


        public void Create(Aircraft item)
        {
            try
            {
                dbContext.Aircrafts.Add(item);
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
                Aircraft aircraftFromDb = Read(key);
                dbContext.Aircrafts.Remove(aircraftFromDb);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Aircraft> Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<Aircraft> query = dbContext.Aircrafts;
                if (useNavigationalProperties)
                {
                    query = query.Include(a => a.Brand)
                                 .Include(a => a.Model);
                }
                return await query.FirstOrDefaultAsync(a => a.Id == key);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Aircraft> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                return dbContext.Aircrafts.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Aircraft item, bool useNavigationalProperties = false)
        {
            try
            {
                dbContext.Aircrafts.Update(item);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
