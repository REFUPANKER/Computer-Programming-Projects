using HesapKabardiT1.Managers;
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
		public static UserManager mUser = new UserManager();
		public static RoomManager mRoom = new RoomManager();
		public static DatabaseManager dbm = new DatabaseManager();

		//public static ChatMenu wChat = new ChatMenu();
	}
}
