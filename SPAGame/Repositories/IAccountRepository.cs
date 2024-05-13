using SPAGame.Models;

namespace SPAGame.Repositories
{
    public interface IAccountRepository
    {
        Account AddAccount(Account account);
        Account GetByEmail(string? AccountEmail);
        Account GetById(int AccountId);
    }
}