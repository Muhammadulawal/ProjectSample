
namespace FileEncryptionAPI.Repository;

public class DbConnection : IDbConnection
{
    private readonly IConfiguration _config;
    private readonly IMongoDatabase _db;
    private string _connectionString = "MongoDB";
    public string DbName { get; private set; }
    public string UserCollectionName { get; private set; } = "users";
    public string FileCollectionName { get; private set; } = "files";

    public MongoClient Client { get; private set; }
    public IMongoCollection<UserModel> UserCollection { get; private set; }
    public IMongoCollection<FileModel> FileCollection { get; private set; }

    public DbConnection(IConfiguration config)
    {
        _config = config;
        Client = new MongoClient(_config.GetConnectionString(_connectionString));
        DbName = _config["DatabaseName"];
        _db = Client.GetDatabase(DbName);

        UserCollection = _db.GetCollection<UserModel>(UserCollectionName);
        FileCollection = _db.GetCollection<FileModel>(FileCollectionName);
    }
} 
