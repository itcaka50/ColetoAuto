using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer;
using DataLayer;

namespace ServiceLayer2
{
    public class CarManager
    {
        private readonly CarContext carContext;

        public CarManager(CarContext carContext)
        {
            this.carContext = carContext;
        }

        public async Task CreateAsync(Car item)
        {
            await carContext.CreateAsync(item);
        }

        public async Task<Car> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await carContext.ReadAsync(key, useNavigationalProperties, isReadOnly);
        }

        public async Task<ICollection<Car>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await carContext.ReadAllAsync(useNavigationalProperties, isReadOnly);
        }

        public async Task UpdateAsync(Car item, bool useNavigationalProperties = false)
        {
            await carContext.UpdateAsync(item, useNavigationalProperties);
        }

        public async Task DeleteAsync(int key)
        {
            await carContext.DeleteAsync(key);
        }
    }
}
