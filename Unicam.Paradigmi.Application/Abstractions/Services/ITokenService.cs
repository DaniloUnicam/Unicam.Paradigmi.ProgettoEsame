namespace Unicam.Paradigmi.Application.Abstractions.Services
{
	public interface ITokenService
	{
		public Task<string> CreateTokenAsync(string email, string password);

	}
}
