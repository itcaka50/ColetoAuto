using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer;

namespace ServiceLayer
{
    public class AircraftManager
    {
        private readonly AircraftContext aircraftContext;

        public AircraftManager(AircraftContext aircraftContext)
        {
            this.aircraftContext = aircraftContext;
        }

        public async Task CreateAsync(Aircraft item)
        {
            await aircraftContext.CreateAsync(item);
        }

        public async Task<Aircraft> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await aircraftContext.ReadAsync(key, useNavigationalProperties, isReadOnly);
        }

        public async Task<ICollection<Aircraft>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await aircraftContext.ReadAllAsync(useNavigationalProperties, isReadOnly);
        }

        public async Task UpdateAsync(Aircraft item, bool useNavigationalProperties = false)
        {
            await aircraftContext.UpdateAsync(item, useNavigationalProperties);
        }

        public async Task DeleteAsync(int key)
        {
            await aircraftContext.DeleteAsync(key);
        }
    }
}
