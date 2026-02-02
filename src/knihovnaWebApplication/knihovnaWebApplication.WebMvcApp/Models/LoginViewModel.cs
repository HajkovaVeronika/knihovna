using knihovnaWebApplication.WebMvcApp.Entities;

namespace knihovnaWebApplication.WebMvcApp.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<User> Users { get; set; }

        public LoginViewModel()
        {
        }
    }
}
