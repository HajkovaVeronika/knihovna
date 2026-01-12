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

        public User(int userId, string userName, string password)
        {
            UserId = userId;
            UserName = userName;
            Password = password;
        }

        [Key]
        [Column("userId")]
        public int UserId { get; set; }
        [Column("userName")]
        public string UserName { get; set; }
        [Column("password")]
        public string Password { get; set; }
    }
}
