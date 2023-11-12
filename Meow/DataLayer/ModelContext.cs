using BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ModelContext : IDb<Model, int>
    {
        MeowDbContext dbContext;
        public ModelContext(MeowDbContext dbContext_)
        {
            this.dbContext = dbContext_;
        }


        public void Create(Model item)
        {
            try
            {
                dbContext.Models.Add(item);
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
                Model modelFromDb = Read(key);
                dbContext.Models.Remove(modelFromDb);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Model Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                return dbContext.Models.Find(key);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Model> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                return dbContext.Models.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Model item, bool useNavigationalProperties = false)
        {
            try
            {
                dbContext.Models.Update(item);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
