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

        public Brand Brand { get; set; }

        [ForeignKey("Model")]
        public int ModelIdF { get; set; }

        public Model Model { get; set; }

        private Boat()
        {
                
        }
        public Boat(double price, int hp, string description, int brandId, int ModelId)
        {
            Price = price;
            Hp = hp;
            Description = description;
            BrandIdF = brandId;
            ModelIdF = ModelId;
        }
    }
}
