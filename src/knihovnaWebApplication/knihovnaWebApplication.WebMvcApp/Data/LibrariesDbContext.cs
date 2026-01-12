using Microsoft.EntityFrameworkCore;
using knihovnaWebApplication.WebMvcApp.Entities;
using Org.BouncyCastle.Bcpg.OpenPgp;


namespace knihovnaWebApplication.WebMvcApp.Data
{
    public class LibrariesDbContext : DbContext
    {

        public DbSet<Library> Libraries { get; set; } 
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseMySQL("server=mysqlstudenti.litv.sssvt.cz;database=4c1_hajkovaveronika_db2;user=hajkovaveronika;password=123456");
        }
    }
}
