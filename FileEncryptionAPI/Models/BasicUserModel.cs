namespace FileEncryptionAPI.Models;

public class BasicUserModel
{

    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Username { get; set; }

    public BasicUserModel()
    {

    }

    public BasicUserModel(UserModel user)
    {
        Id = user.Id;
        Username = user.Username;
    }

}

