using System.IdentityModel.Tokens.Jwt;

namespace SPAGame.Repositories
{
    public interface ITokenRepository
    {
        public string CreateToken(int id);
        public JwtSecurityToken VerifyToken(string? jwt);
    }
}
