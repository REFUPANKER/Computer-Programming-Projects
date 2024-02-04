using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HesapKabardiT1.Items
{
	public class Room
	{
		public int? ID { get; set; }
		public string? Name { get; set; }
		public int? Player1 { get; set; }
		public int? Player2 { get; set; }
		public int? TP1 { get; set; }
		public int? TP2 { get; set; }
		public int? Turn { get; set; }
	}
}
