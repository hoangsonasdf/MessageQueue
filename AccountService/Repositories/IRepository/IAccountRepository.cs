using Core.Model;

namespace AccountService.Repositories.IRepository
{
    public interface IAccountRepository
    {
        Task AddAccount(Account account);
    }
}
