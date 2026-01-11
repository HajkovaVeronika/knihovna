using Microsoft.EntityFrameworkCore;
using knihovnaWebApplication.WebMvcApp.Entities;

     /*
     * 0. prerekvizita: dát atributy nad entitní třídu, stáhnout baličky z NuGet (microsoft.entityFrameworkCore, mySql.entityFrameworkCore)
     * 1. podědit dbcontext
     * 2. vytvořit DbSety pro jednotlivé entity
     * 3. Nastavit tzv. connection string (na jakej server, do jaké databazé, s jakými přihlašovacími udáji)
     */

namespace knihovnaWebApplication.WebMvcApp.Data
{
    public class LibrariesDbContext : DbContext
    {

        public DbSet<Library> Libraries { get; set; } //dá se pracovat jako s listem
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //napsat override a mezeru - vyhledat oncofiguring - vygeneruje
        {
            optionsBuilder.UseMySQL("server=mysqlstudenti.litv.sssvt.cz;database=4c1_hajkovaveronika_db2;user=hajkovaveronika;password=123456");
        }
    }
}
