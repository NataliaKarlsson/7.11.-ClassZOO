using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace _7._11._ClassZOO.Models.Viewmodels
{
    public class CreateAnimalsViewModel

    {
        [Display(Name = "Animal")]
        [Required]
        public string? AnimalName { get; set; }
        [Required]
        public string? Spesies { get; set; }
        [StringLength(80, MinimumLength = 1)]
        [Required]
        public string? CalleByName { get; set; }
        public double Quantity { get; set; }



        public List<string> SpesiesList
        {
            get
            {
                return new List<string>
                {
                    "mammal", "reptile", "fishes", "insects", "birds", "spineless"
                };
            }
        }

    }
}