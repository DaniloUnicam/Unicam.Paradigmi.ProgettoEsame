namespace Unicam.Paradigmi.Application.Abstractions.Services
{
	public interface ITokenService
	{
		Task<string> CreateTokenStringAsync(string email, string password);

	}
}
