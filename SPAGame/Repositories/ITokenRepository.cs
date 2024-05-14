using SPAGame.Models;

namespace SPAGame.Repositories
{
    public interface ITokenRepository
    {
        string CreateToken(AccountModel account);
        //public JwtSecurityToken VerifyToken(string? jwt);
    }
}
