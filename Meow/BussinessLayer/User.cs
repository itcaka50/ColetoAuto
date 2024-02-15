using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace BussinessLayer
{
    public class User : IdentityUser
    {
        [Required]
        public string Adress { get; set; }

        [Required, Range(1, 101)]
        public int Age { get; set; }

        [Required]
        public string Phone { get; set; }

        public ICollection<Car> Cars { get; set; }

        public User()
        {
            this.Cars = new List<Car>();
        }

        public User(string username_, string adress, int age, string email, string phone)
        {
            UserName = username_;
            Adress = adress;
            Age = age;
            Email = email;
            Phone = phone;
            this.Cars = new List<Car>();
        }
    }
}
