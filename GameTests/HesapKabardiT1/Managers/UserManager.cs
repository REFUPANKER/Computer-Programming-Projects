using HesapKabardiT1.Items;
using System.Data;
namespace HesapKabardiT1.Managers
{
	public class UserManager
	{
		public User GetUserData(int id)
		{
			//DataTable? db = DatabaseManager.RequestQuery($"select * from User where id ={id}", true);
			return new User(1, "qwe", "qweqwe", "123912378", 0);
		}
	}
}
