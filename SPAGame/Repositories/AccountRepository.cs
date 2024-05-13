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

        public Account AddAccount(Account _account)
        {
            _dbContext.Accounts.Add(_account);
            _dbContext.SaveChanges();

            return _account;
        }

        //Skriv kod som skapar en ny rad inuti Profiles i databasen
        //när kontot skapas, t.ex. med hjälp av Profiles.

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