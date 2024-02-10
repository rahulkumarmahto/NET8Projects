using FirstWebApi.Models;
using FirstWebApi.Repositories;

namespace FirstWebApi.Services
{
    public interface IAccountService
    {
        Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
    }

    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            var response = await accountRepository.LoginAsync(loginRequest);

            //some business logics.

            return response;
        }
    }
}
