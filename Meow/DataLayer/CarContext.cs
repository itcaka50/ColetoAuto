using BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CarContext : IDb<Car, int>
    {
        MeowDbContext dBContext;

        public CarContext(MeowDbContext dBContext_)
        {
            this.dBContext = dBContext_;
        }

        public void Create(Car item)
        {
            try
            {
                dBContext.Add(item);
                dBContext.SaveChanges();
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
                Car carFromDb = dBContext.Cars.Find(key);
                if (carFromDb != null)
                {
                    dBContext.Cars.Remove(carFromDb);
                    dBContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Car Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
               return dBContext.Cars.Find(key);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Car> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                return dBContext.Cars;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Car item, bool useNavigationalProperties = false)
        {
            try
            {
                dBContext.Cars.Update(item);
                dBContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
