using SPAGame.Models;

namespace SPAGame.Repositories
{
    public interface IAccountRepository
    {
        Account Create(Account account);
        Account GetByEmail(string accountEmail);
        Account GetById(int accountId);
    }
}
