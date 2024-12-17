

using FileEncryptionAPI.Services;

namespace FileEncryptionAPI.Models;

public class FileModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string FileName { get; set; }
    public byte[] EncryptedFile { get; set; }
    public BasicUserModel UploadedBy { get; set; }
    public DateTime DateUploaded { get; set; } = DateTime.UtcNow;
    public bool IsEncrypted { get; set; } = true;
    public bool IsArchived { get; set; } = false;
    public bool IsDeleted { get; set; } = false;

    public FileModel(FileDTO f)
    {
        EncryptedFile = FileEncryption.EncryptFile(f.EncryptedFile);
    }
}
