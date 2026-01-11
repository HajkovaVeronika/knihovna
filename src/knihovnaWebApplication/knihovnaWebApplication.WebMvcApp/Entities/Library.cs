using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace knihovnaWebApplication.WebMvcApp.Entities
{
    [Table("libraries")]
    public class Library
    {


        [Key]
        [Column("libraryId")]
        public int LibraryId { get; set; }
        [Column("name")]
        public string Name { get; set; }

    }
}
