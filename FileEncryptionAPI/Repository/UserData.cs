

namespace FileEncryptionAPI.Repository;

public class UserData : IUserData
{
    public readonly IMongoCollection<UserModel> _users;
    public UserData(IDbConnection db)
    {
        _users = db.UserCollection;
    }

    public async Task<List<UserModel>> GetUsersAsync()
    {
        var results = await _users.FindAsync(_ => true);
        return results.ToList();
    }

    public async Task<UserModel> GetUser(string id)
    {
        var result = await _users.FindAsync(u => u.Id == id);
        return result.FirstOrDefault();
    }

    public async Task<UserModel> GetUserFromAuthentication(string username, string password)
    {
        var result = await _users.FindAsync(u => u.Username == username && u.PasswordHash == password);
        return result.FirstOrDefault();
    }

    public Task CreateUser(UserModel user)
    {
        return _users.InsertOneAsync(user);
    }

    public Task UpdateUser(UserModel user)
    {
        var filter = Builders<UserModel>.Filter.Eq("Id", user.Id);
        return _users.ReplaceOneAsync(filter, user, new ReplaceOptions { IsUpsert = true });
    }

}
