using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public int? Player2 { get; set; }
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public int? TP1 { get; set; }
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public int? TP2 { get; set; }
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public int? Turn { get; set; }

		public override string ToString()
		{
			return $"{ID}\t|{Name}\t|{(Turn != null && Turn.Value == 1 ? "Your Turn" : "Enemy's Turn")}";
		}
	}
}
