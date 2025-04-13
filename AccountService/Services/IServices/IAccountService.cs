using Core.DTOs.Request;

namespace AccountService.Services.IServices
{
    public interface IAccountService
    {
        Task AddAccount(AddAccountRequest account);
    }
}
