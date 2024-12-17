using FileEncryptionAPI.Services;

namespace FileEncryptionAPI.DTOs;

public class FileDTO
{
    public string FileName { get; set; }
    public byte[] EncryptedFile { get; set; }

}
