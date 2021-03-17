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
		[StringLength(60, MinimumLength = 3)]
		[RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
		public string ContractName { get; set; }

		[Required]
		[RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
		public string Name { get; set; }

		[Required]
		[RegularExpression(@"^[A-Z]+[a-zA-Z0-9]*$")]
		[StringLength(50)]
		public string Address { get; set; }

		[Required]
		[Range(-90, 90)]
		public decimal Latitude { get; set; }

		[Required]
		[Range(-180, 180)]
		public decimal Longitude { get; set; }

		[Required]
		public bool Banking { get; set; }
		
		public int AvailableBikes { get; set; }

		public int AvailableStands { get; set; }

		[Required]
		public int Capacity { get; set; }

		[RegularExpression(@"^(OPEN|CLOSE)$")]
		public string Status { get; set; }
	}
}
