using HesapKabardiT1.Managers;
using System;

namespace HesapKabardiT1.Pool
{
	/// <summary>
	///	<u>App System Managers</u>
	/// <br/>	- <see cref="UserManager"/> -> mUser
	/// <br/>	- <see cref="RoomManager"/> -> mRoom
	/// <br/>	<u>Database Access Manager</u>
	/// <br/>	- <see cref="DatabaseManager"/> -> dbm
	/// <br/>	<u>UI Windows</u>
	/// <br/>	- <see cref="ChatMenu"/> -> wChat
	/// </summary>
	public class Core
	{
		public static Random rnd = new Random();

		public static ActionInvoker actinv = new ActionInvoker();

		public static UserManager mUser = new UserManager();
		public static DatabaseManager dbm = new DatabaseManager();

		public static ChatMenu wChat = new ChatMenu();

		public static string RandomName_GameRoom(int length)
		{
			string r = "";
			for (int i = 0; i < length; i++)
			{
				if (rnd.Next(0, 2) == 1 && r.Length > 1 && i + 1 < length)
				{
					r += rnd.Next(0, 10);
				}
				else
				{
					r += ((char)rnd.Next(65, 91));
				}
			}
			return r;
		}
	}
}
