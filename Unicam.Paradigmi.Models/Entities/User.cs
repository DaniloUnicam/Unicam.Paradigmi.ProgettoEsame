namespace Unicam.Paradigmi.Models.Entities
{
	public class User
	{
		public User()
		{
			Name = string.Empty;
			Surname = string.Empty;
			Email = string.Empty;
			Password = string.Empty;
		}

		public int IdUtente { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
