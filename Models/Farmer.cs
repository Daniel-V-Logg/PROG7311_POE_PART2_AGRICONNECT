using System.ComponentModel.DataAnnotations;

namespace AgriEnergyConnect.Models
{
    public class Farmer
    {
        [Key]
        public int FarmerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
