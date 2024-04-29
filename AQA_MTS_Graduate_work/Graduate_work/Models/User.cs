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

    public class Builder
    {
        private string _email = string.Empty;
        private string _password = string.Empty;

        public Builder SetEmail(string email)
        {
            _email = email;
            return this;
        }

        public Builder SetPassword(string password)
        {
            _password = password;
            return this;
        }

        public User Build()
        {
            if (string.IsNullOrEmpty(_email))
            {
                throw new InvalidOperationException("_email shouldn't be empty");
            }

            if (string.IsNullOrEmpty(_password))
            {
                throw new InvalidOperationException("_password shouldn't be empty");
            }

            return new User(_email, _password);
        }
    }
}