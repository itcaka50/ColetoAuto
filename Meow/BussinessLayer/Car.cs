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
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Price should be greater than 0!")]
        public double Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Mileage should be greater than 0!")]
        public int Mileage { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "HorsePower should be greater than 0!")]
        public int HorsePower { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public User @User { get; set; }
        
        [ForeignKey("Model")]
        public int ModelId { get; set; }

        [Required]
        public Model @Model { get; set; }

        public Car() 
        {

        }

        public Car(double price_, int mileage_, int horsePower_, string description_, Model model_, User user_)
        {
            this.Price = price_;
            this.Mileage = mileage_;
            this.HorsePower = horsePower_;
            this.Description = description_;
            this.@Model = model_;
            this.@User = user_;
        }
    }
}
