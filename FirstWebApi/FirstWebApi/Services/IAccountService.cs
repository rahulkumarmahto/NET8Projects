using FirstWebApi.Models;
using FirstWebApi.Repositories;

namespace FirstWebApi.Services
{
    public interface IAccountService
    {
        Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
        Task ChangePasswordAsync(PasswordChangeRequest passwordChangeRequest);

    }

    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public async Task ChangePasswordAsync(PasswordChangeRequest passwordChangeRequest)
        {
            await this.accountRepository.ChangePasswordAsync(passwordChangeRequest).ConfigureAwait(false);
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            var response = await accountRepository.LoginAsync(loginRequest).ConfigureAwait(false);

            //some business logics.

            return response;
        }
    }
}
