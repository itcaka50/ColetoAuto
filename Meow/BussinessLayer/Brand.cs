using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandId { get; set; }

        [Required]
        public string Name { get; set; }


        [Required]
        public ICollection<Model> Models { get; set; }

        [Required]
        public ICollection<Aircraft> Aircrafts { get; set; }

        [Required]
        public ICollection<Boat> Boats { get; set; }



        private Brand()
        {
            this.Models = new List<Model>();
            this.Aircrafts = new List<Aircraft>();
            this.Boats = new List<Boat>();
        }
        
        public Brand(string name_)
        {
            this.Name = name_;
            this.Models = new List<Model>();
            this.Aircrafts = new List<Aircraft>();
            this.Boats = new List<Boat>();
        }
    }
}
