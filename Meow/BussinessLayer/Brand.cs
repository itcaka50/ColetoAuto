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
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        
        public ICollection<Model> Models { get; set; }

        public Brand()
        {
            this.Models = new List<Model>();
        }
        
        public Brand(string name_)
        {
            this.Name = name_;
            this.Models = new List<Model>();
            
        }
    }
}
