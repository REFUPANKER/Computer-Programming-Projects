using HesapKabardiT1.Managers;
using HesapKabardiT1.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HesapKabardiT1.Items
{
	public class User : UserTemplate
	{
		public User(int iD, string name, string email, string password, int tokens) : base(iD, name, email, password, tokens) { }

		//DatabaseManager.RequestQuery()
		public void UpdatePassword(string password) { }
		public void UpdateName(string name) { }
		public void UpdateToken(int tokens) { }
	}
}
