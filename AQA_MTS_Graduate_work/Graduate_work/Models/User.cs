namespace Graduate_work.Models;

public class User
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public User(string email, string password)
    {
        Email = email;
        Password = password;
    }
}