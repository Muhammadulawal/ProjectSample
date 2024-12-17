
namespace FileEncryptionAPI.Repository;

public class FileData : IFileData
{
    private readonly IDbConnection _db;
    private readonly IUserData _userData;
    private readonly IMemoryCache _cache;
    private readonly IMongoCollection<FileModel> _files;
    public const string CacheName = "FileData";

    public FileData(IDbConnection db, IUserData userData, IMemoryCache cache)
    {
        _db = db;
        _userData = userData;
        _cache = cache;
        _files = db.FileCollection;
    }

    public async Task<List<FileModel>> GetAllFiles()
    {
        var output = _cache.Get<List<FileModel>>(CacheName);
        if (output == null)
        {
            var results = await _files.FindAsync(s => s.IsArchived == false);
            output = results.ToList();

            _cache.Set(CacheName, output, TimeSpan.FromMinutes(1));
        }

        return output;
    }

    public async Task<List<FileModel>> GetUsersFiles(string userId)
    {
        var output = _cache.Get<List<FileModel>>(userId);
        if (output == null)
        {
            var results = await _files.FindAsync(s => s.UploadedBy.Id == userId);
            output = results.ToList();

            _cache.Set(userId, output, TimeSpan.FromMinutes(1));
        }
        return output;
    }

    public async Task<List<FileModel>> GetAllEncryptedFiles()
    {
        var output = await GetAllFiles();
        return output.Where(x => x.IsEncrypted).ToList();
    }

    public async Task<FileModel> GetFile(string id)
    {
        var result = await _files.FindAsync(s => s.Id == id);
        return result.FirstOrDefault();
    }



    public async Task CreateFile(FileModel file)
    {
        var client = _db.Client;
        using var session = await client.StartSessionAsync();

        session.StartTransaction();

        try
        {
            var db = client.GetDatabase(_db.DbName);
            var fileInTransaction = db.GetCollection<FileModel>(_db.FileCollectionName);
            await fileInTransaction.InsertOneAsync(file);

            var userInTransaction = db.GetCollection<UserModel>(_db.UserCollectionName);
            var user = await _userData.GetUser(file.UploadedBy.Id);
            user.AuthoredFiles.Add(new BasicFileModel(file));
            await userInTransaction.ReplaceOneAsync(u => u.Id == user.Id, user);

            await session.CommitTransactionAsync();
        }
        catch (Exception ex)
        {
            await session.AbortTransactionAsync();
            throw;
        }
    }

    public async Task DeleteFile(FileModel file)
    {
        //var client = _db.Client;
        //using var session = await client.StartSessionAsync();

        //session.StartTransaction();

        //try
        //{
        //    var db = client.GetDatabase(_db.DbName);
        //    var fileInTransaction = db.GetCollection<FileModel>(_db.FileCollectionName);
        //    var user = await _fileData(file.UploadedBy.Id);
        //    await fileInTransaction.InsertOneAsync(file);

        //    var userInTransaction = db.GetCollection<UserModel>(_db.UserCollectionName);
        //    var user = await _userData.GetUser(file.UploadedBy.Id);
        //    user.AuthoredFiles.Add(new BasicFileModel(file));
        //    await userInTransaction.ReplaceOneAsync(u => u.Id == user.Id, user);

        //    await session.CommitTransactionAsync();
        //}
        //catch (Exception ex)
        //{
        //    await session.AbortTransactionAsync();
        //    throw;
        //}
    }

}
