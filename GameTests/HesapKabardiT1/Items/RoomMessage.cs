using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HesapKabardiT1.Items
{
	public class RoomMessage
	{
		public int? ID { get; set; }
		public int? Room { get; set; }
		public int? Sender { get; set; }
		public string? Message { get; set; }
	}
}
