namespace FileEncryptionAPI;

public static class RegisterServices
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddMemoryCache();

        builder.Services.AddScoped<IDbConnection, DbConnection>();

        builder.Services.AddScoped<IFileData, FileData>();
        builder.Services.AddScoped<IUserData, UserData>();
    }
}
