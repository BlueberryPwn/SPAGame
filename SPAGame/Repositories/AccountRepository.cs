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

        public AccountModel AddAccount(AccountModel _account)
        {
            _dbContext.Accounts.Add(_account);
            _dbContext.SaveChanges();

            return _account;
        }

        public AccountModel GetByEmail(string? AccountEmail)
        {
            return _dbContext.Accounts.FirstOrDefault(a => a.AccountEmail == AccountEmail);
        }

        public AccountModel GetById(int AccountId)
        {
            return _dbContext.Accounts.FirstOrDefault(a => a.AccountId == AccountId);
        }
    }
}