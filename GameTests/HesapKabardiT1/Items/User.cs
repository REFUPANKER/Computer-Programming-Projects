using HesapKabardiT1.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HesapKabardiT1.Items
{
	public class User
	{
		public int? ID { get; set; }
		public string? Name { get; set; }
		public string? Email { get; set; }
		public string? Password { get; set; }
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public int? Tokens { get; set; }
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public int? Active { get; set; }
	}
}
