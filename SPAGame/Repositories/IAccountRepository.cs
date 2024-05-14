using SPAGame.Models;

namespace SPAGame.Repositories
{
    public interface IAccountRepository
    {
        AccountModel AddAccount(AccountModel account);
        AccountModel GetByEmail(string? AccountEmail);
        AccountModel GetById(int AccountId);
    }
}