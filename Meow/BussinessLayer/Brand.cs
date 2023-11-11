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

        private Brand()
        {
            Models = new List<Model>();
        }
        
        public Brand(int brandId, ICollection<Model> models)
        {
            this.BrandId = brandId;
            this.Models = models;
        }
    }
}
