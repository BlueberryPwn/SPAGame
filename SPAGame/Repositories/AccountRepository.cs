using Microsoft.EntityFrameworkCore;
using SPAGame.Data;
using SPAGame.Models;

namespace SPAGame.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Account Create(Account account)
        {
            _dbContext.Accounts.Add(account);
            account.AccountId = _dbContext.SaveChanges();

            return account;
        }

        public Account GetByEmail(string? AccountEmail)
        {
            return _dbContext.Accounts.FirstOrDefault(a => a.AccountEmail == AccountEmail);
        }

        public Account GetById(int AccountId)
        {
            return _dbContext.Accounts.FirstOrDefault(a => a.AccountId == AccountId);
        }
    }
}
