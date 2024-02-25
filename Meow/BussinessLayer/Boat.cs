using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class Boat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Range(0, int.MaxValue)]
        public double Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Hp { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [ForeignKey("Brand")]
        public int BrandIdF { get; set; }

        public Brand brand { get; set; }


        private Boat()
        {
                
        }
        public Boat(double price, int hp, string description, Brand brand_)
        {
            Price = price;
            Hp = hp;
            Description = description;
            brand = brand_;
        }
    }
}
