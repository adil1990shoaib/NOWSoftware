using Dapper;
using Domain;
using System.Data;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        /// <inheritdoc />
        public async Task<int> AddUserAsync(User user)
        {
            var sql = "INSERT INTO Users (Username, Password, FirstName, LastName, Device, IPAddress, Balance) VALUES (@Username, @Password, @FirstName, @LastName, @Device, @IPAddress, @Balance); SELECT CAST(SCOPE_IDENTITY() as int);";
            return await _dbConnection.QuerySingleAsync<int>(sql, user);
        }

        /// <inheritdoc />
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var sql = "SELECT * FROM Users WHERE Username = @Username";
            return await _dbConnection.QuerySingleOrDefaultAsync<User>(sql, new { Username = username });
        }
    }

}
