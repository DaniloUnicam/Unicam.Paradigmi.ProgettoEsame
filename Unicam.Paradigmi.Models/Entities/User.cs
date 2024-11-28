namespace Unicam.Paradigmi.Models.Entities
{
	public class User
	{
		public User()
		{
			Username = string.Empty;
			Surname = string.Empty;
			Email = string.Empty;
			Password = string.Empty;
		}

		public int UserId { get; set; }
		public string Username { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
