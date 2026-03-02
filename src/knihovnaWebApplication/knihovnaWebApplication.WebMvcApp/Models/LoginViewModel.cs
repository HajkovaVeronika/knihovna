using knihovnaWebApplication.WebMvcApp.Entities;

namespace knihovnaWebApplication.WebMvcApp.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<User> Users { get; set; }
        public bool somethingWrong { get; set; }

        public LoginViewModel()
        {
        }

        public LoginViewModel(string username, string password, List<User> users)
        {
            Username = username;
            Password = password;
            Users = users;
        }
    }
}
