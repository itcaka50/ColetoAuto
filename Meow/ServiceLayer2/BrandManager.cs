using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using System.Threading.Tasks;
using BussinessLayer;

namespace ServiceLayer2
{
    public class BrandManager
    {
        private readonly BrandContext brandContext;

        public BrandManager(BrandContext brandContext)
        {
            this.brandContext = brandContext;
        }

        public async Task CreateAsync(Brand item)
        {
            await brandContext.CreateAsync(item);
        }

        public async Task<Brand> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await brandContext.ReadAsync(key, useNavigationalProperties, isReadOnly);
        }

        public async Task<ICollection<Brand>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await brandContext.ReadAllAsync(useNavigationalProperties, isReadOnly);
        }

        public async Task UpdateAsync(Brand item, bool useNavigationalProperties = false)
        {
            await brandContext.UpdateAsync(item, useNavigationalProperties);
        }

        public async Task DeleteAsync(int key)
        {
            await brandContext.DeleteAsync(key);
        }
    }
}
