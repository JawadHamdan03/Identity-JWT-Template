using SecAndIdentity.Models;

namespace SecAndIdentity.Interfaces.Services;


public interface ITokenService
{
    Task<string> CreateToken(AppUser user);
}