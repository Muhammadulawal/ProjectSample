
namespace FileEncryptionAPI.Models;

public class BasicFileModel
{
   
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string FileName { get; set; }

    public BasicFileModel()
    {
        
    }

    public BasicFileModel(FileModel file)
    {
        Id = file.Id;
        FileName = file.FileName;
    }

}

