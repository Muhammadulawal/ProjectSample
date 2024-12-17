using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FileEncryptionAPI.Models;

public class UserModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string EmailAddress { get; set; }
    public List<BasicFileModel> AuthoredFiles { get; set; } = new();

}
