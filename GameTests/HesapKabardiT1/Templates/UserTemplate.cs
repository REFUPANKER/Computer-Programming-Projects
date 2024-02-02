using HesapKabardiT1.Managers;

namespace HesapKabardiT1.Templates
{
	public class UserTemplate
	{
		public UserTemplate(int iD, string name, string email, string password, int tokens)
		{
			ID = iD;
			Name = name;
			Email = email;
			Password = password;
			Tokens = tokens;
		}

		public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Tokens { get; set; }
    }
}
