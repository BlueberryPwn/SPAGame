using Microsoft.AspNetCore.Identity;

namespace SPAGame.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user);
    }
}
