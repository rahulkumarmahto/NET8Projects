using Dapper;
using FirstWebApi.Models;
using System.Data;
using System.Data.SqlClient;
namespace FirstWebApi.Repositories
{
    public interface IAccountRepository
    {
        Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
    }

    public class AccountRepository : IAccountRepository
    {
        private readonly string connectionString;

        public AccountRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            using IDbConnection connection = new SqlConnection(this.connectionString);
            var result = await connection.QueryFirstAsync<LoginResponse>("SP_GetLoginInfo", new { Username=loginRequest.UserName, password= loginRequest.Password }, null, null, CommandType.StoredProcedure).ConfigureAwait(false);
            return result;
        }
    }
}
