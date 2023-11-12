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
    public class Aircraft
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Range(0, int.MaxValue)]
        public double Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Thrust { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [ForeignKey("Brand")]
        public int BrandIdF { get; set; }

        public Brand Brand { get; set; }

        [ForeignKey("Model")]
        public int ModelIdF { get; set; }

        public Model Model { get; set; }

        private Aircraft()
        {
                
        }

        public Aircraft(int id, double price, int thrust, string description, int brandId, int ModelId)
        {
            Id = id;
            Price = price;
            Thrust = thrust;
            Description = description;
            BrandIdF = brandId;
            ModelIdF = ModelId;
        }
    }
}
