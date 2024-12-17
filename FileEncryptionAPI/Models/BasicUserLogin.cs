using System.ComponentModel.DataAnnotations;

namespace FileEncryptionAPI.Models;

public class BasicUserLogin
{
    [Required(ErrorMessage = "Username is Required")]
    [EmailAddress(ErrorMessage = "Invalid Username")]
    public string Username { get; set; }
    [Required(ErrorMessage = "Password is Required")]
    public string Password { get; set; }
}

