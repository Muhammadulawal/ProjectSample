

namespace FileEncryptionAPI.Repository;

public interface IDbConnection
{
    MongoClient Client { get; }
    string DbName { get; }
    IMongoCollection<FileModel> FileCollection { get; }
    string FileCollectionName { get; }
    IMongoCollection<UserModel> UserCollection { get; }
    string UserCollectionName { get; }
}
