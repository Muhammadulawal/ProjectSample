using FileEncryptionAPI.Models;

namespace FileEncryptionAPI.Repository
{
    public interface IUserData
    {
        Task CreateUser(UserModel user);
        Task<UserModel> GetUser(string id);
        Task<UserModel> GetUserFromAuthentication(string username, string password);
        Task<List<UserModel>> GetUsersAsync();
        Task UpdateUser(UserModel user);
    }
}