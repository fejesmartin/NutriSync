using Microsoft.AspNetCore.Identity;

namespace NutriSyncBackend.Authentication;

public interface ITokenService
{
    string CreateToken(IdentityUser user, string role);
}