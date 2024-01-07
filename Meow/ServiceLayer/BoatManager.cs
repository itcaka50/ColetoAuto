using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer;
using DataLayer;

namespace ServiceLayer
{
    public class BoatManager
    {
        private readonly BoatContext boatContext;

        public BoatManager(BoatContext genreContext)
        {
            this.boatContext = boatContext;
        }

        public async Task CreateAsync(Boat item)
        {
            await boatContext.CreateAsync(item);
        }

        public async Task<Boat> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await boatContext.ReadAsync(key, useNavigationalProperties, isReadOnly);
        }

        public async Task<ICollection<Boat>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await boatContext.ReadAllAsync(useNavigationalProperties, isReadOnly);
        }

        public async Task UpdateAsync(Boat item, bool useNavigationalProperties = false)
        {
            await boatContext.UpdateAsync(item, useNavigationalProperties);
        }

        public async Task DeleteAsync(int key)
        {
            await boatContext.DeleteAsync(key);
        }
    }
}
