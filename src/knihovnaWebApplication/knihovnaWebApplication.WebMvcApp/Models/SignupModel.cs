namespace knihovnaWebApplication.WebMvcApp.Models
{
    public class SignupModel
    {
        public SignupModel()
        {
        }

        public SignupModel(string username, string password, string confirmPassword)
        {
            Username = username;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        public string Username{ get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool WrongPassword { get; set; }
        public bool ExistingUsername { get; set; }
    }
}
