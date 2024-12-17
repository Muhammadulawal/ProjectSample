
namespace FileEncryptionAPI.Repository
{
    public interface IFileData
    {
        Task CreateFile(FileModel file);
        Task DeleteFile(FileModel file);
        Task<List<FileModel>> GetAllEncryptedFiles();
        Task<List<FileModel>> GetAllFiles();
        Task<FileModel> GetFile(string id);
        Task<List<FileModel>> GetUsersFiles(string userId);
    }
}