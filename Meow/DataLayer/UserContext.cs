using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BussinessLayer;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserContext : IDb<User, int>
    {
        MeowDbContext dBContext;

        public UserContext(MeowDbContext dBContext_)
        {
            this.dBContext = dBContext_;
        }

        public async Task Create(User user)
        {
            try
            {
                dBContext.Users.Add(user);
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
                User userFromDB = Read(key);
                dBContext.Users.Remove(userFromDB);
                dBContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                return dBContext.Users.Find(key);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<User> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                return dBContext.Users.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(User item, bool useNavigationalProperties = false)
        {
            try
            {
                dBContext.Users.Update(item);
                dBContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
