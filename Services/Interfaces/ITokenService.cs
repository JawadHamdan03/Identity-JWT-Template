using SecAndIdentity.Models;

namespace SecAndIdentity.Interfaces.Services;


public interface ITokenService
{
    string CreateToken(AppUser user);
}