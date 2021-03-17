using System;
using System.ComponentModel.DataAnnotations;

namespace DublinBike.Models
{
    public class Bike
    {
        [Key]
        [Required]
        public int Number { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z ]*$")]
        public string ContractName { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z ]*$")]
        public string Name { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9 ]*$")]
        public string Address { get; set; }

        [Required]
        [Range(-90, 90)]
        public decimal Latitude { get; set; }

        [Required]
        [Range(-180, 180)]
        public decimal Longitude { get; set; }

        [Required]
        public bool Banking { get; set; }

        [Range(0, Int32.MaxValue)]
        public int AvailableBikes { get; set; }

        [Range(0, Int32.MaxValue)]
        public int AvailableStands { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int Capacity { get; set; }

        [Required]
        [RegularExpression(@"^(OPEN|CLOSE)$")]
        public string Status { get; set; }
    }
}
