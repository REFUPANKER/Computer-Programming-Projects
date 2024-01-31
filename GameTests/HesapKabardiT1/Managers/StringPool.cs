using System;
namespace HesapKabardiT1.Managers
{
	public class StringPool
	{
		public static string MsSqlCon { get => $"server={Environment.MachineName};database=HesapKabardi;Trusted_Connection=True;"; }
	}
}
