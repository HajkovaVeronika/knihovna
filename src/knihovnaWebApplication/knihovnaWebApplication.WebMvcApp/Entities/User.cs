using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace knihovnaWebApplication.WebMvcApp.Entities
{
    [Table("users")]
    public class User
    {
        public User()
        {
        }

        public User(int userId, string username, string password)
        {
            UserId = userId;
            Username = username;
            Password = password;
        }

        [Key]
        [Column("userId")]
        public int UserId { get; set; }
        [Column("userName")]
        public string Username { get; set; }
        [Column("password")]
        public string Password { get; set; }
    }
}
