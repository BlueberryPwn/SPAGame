using SPAGame.Models;

namespace SPAGame.Repositories
{
    public interface ITokenRepository
    {
        string CreateToken(Account account);
        //public JwtSecurityToken VerifyToken(string? jwt);
    }
}
