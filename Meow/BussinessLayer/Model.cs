using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace BussinessLayer
{
    public class Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        public Brand @Brand { get; set; }

        public Model() 
        {
        }

        public Model(string name, Brand brand_)
        {
            this.Name = name;
            this.Brand = brand_;
        }

    }
}
