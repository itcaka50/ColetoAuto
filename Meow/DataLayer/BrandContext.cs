using BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BrandContext : IDb<Brand, int>
    {
       
 
        MeowDbContext dBContext;

        public BrandContext(MeowDbContext dBContext_)
        {
            this.dBContext = dBContext_;
        }

        public void Create(Brand brand)
        {
            try
            {
                dBContext.Brands.Add(brand);
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
                Brand brandFromDB = Read(key);  
                dBContext.Brands.Remove(brandFromDB);
                dBContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Brand Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                return dBContext.Brands.Find(key);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Brand> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                return dBContext.Brands.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Brand item, bool useNavigationalProperties = false)
        {
            try
            {
                dBContext.Brands.Update(item);
                dBContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
