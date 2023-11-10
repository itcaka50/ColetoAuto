using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace BussinessLayer
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3), Required]
        public string Name { get; set; }

        [Required, MinLength(7)]
        public string Password { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required, Range(1, 101)]
        public int Age { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        private User()
        {

        }

        public User(int id, string name, string pass, string adress, int age, string email, string phone)
        {
            Id = id;
            Name = name;
            Password = pass;
            Adress = adress;
            Age = age;
            Email = email;
            Phone = phone;
        }
    }
}
