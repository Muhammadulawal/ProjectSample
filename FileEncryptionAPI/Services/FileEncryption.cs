
namespace FileEncryptionAPI.Services;

public class FileEncryption
{
    public static void EncryptFile(string inputFile, string outputFile, byte[] key, byte[] iv)
    {
        using (FileStream fsInput = new FileStream(inputFile, FileMode.Open))
        using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create))
        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;

            using (CryptoStream cryptoStream = new CryptoStream(fsOutput, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                fsInput.CopyTo(cryptoStream);
            }
        }
    }
    public static void DecryptFile(string inputFile, string outputFile, byte[] key, byte[] iv)
    {
        using (FileStream fsInput = new FileStream(inputFile, FileMode.Open))
        using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create))
        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;

            using (CryptoStream cryptoStream = new CryptoStream(fsInput, aes.CreateDecryptor(), CryptoStreamMode.Read))
            {
                cryptoStream.CopyTo(fsOutput);
            }
        }
    }

//    using (Aes aes = Aes.Create())
//{
//    aes.GenerateKey();
//    aes.GenerateIV();

//    byte[] key = aes.Key;
//byte[] iv = aes.IV;
//}

}
