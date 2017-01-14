using System;
using System.ComponentModel.DataAnnotations;
namespace CrossTown
{
	public class EmailViewModel
	{
		[Required]
		public string email_address { get; set; }

		[Required]
		public string name { get; set; }

		[Required]
		public string phone { get; set; }

		[Required]
		public string comments { get; set; }

		public string section { get;  set; }
	}
}
