using Domain;

namespace Infrastructure.Repository
{
    /// <summary>
    /// User Interface to manage user
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// AddUserAsync
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<int> AddUserAsync(User user);

        /// <summary>
        /// GetUserByUsernameAsync
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<User> GetUserByUsernameAsync(string username);
    }
}
