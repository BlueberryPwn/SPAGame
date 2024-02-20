using SPAGame.Data;
using SPAGame.Models;

namespace SPAGame.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Account Create(Account account)
        {
            _context.Accounts.Add(account);
            account.AccountId = _context.SaveChanges();

            return account;
        }

        public Account GetByEmail(string accountEmail)
        {
            return _context.Accounts.First(a => a.AccountEmail == accountEmail);
        }

        public Account GetById(int accountId)
        {
            return _context.Accounts.First(a => a.AccountId == accountId);
        }
    }
}
