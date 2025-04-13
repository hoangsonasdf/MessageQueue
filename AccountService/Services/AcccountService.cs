using AccountService.Repositories.IRepository;
using AccountService.Services.IServices;
using Core.DTOs.Request;
using Core.Model;

namespace AccountService.Services
{
    public class AcccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AcccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task AddAccount(AddAccountRequest request)
        {
            var newAccount = new Account
            {
                UserName = request.UserName,
                Password = request.Password,
                StudentId = request.StudentId
            };

            await _accountRepository.AddAccount(newAccount);
        }
    }
}
