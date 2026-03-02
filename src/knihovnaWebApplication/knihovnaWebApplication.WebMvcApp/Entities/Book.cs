using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace knihovnaWebApplication.WebMvcApp.Entities
{
    [Table("books")]
    public class Book
    {
        public Book()
        {
        }

        public Book(int bookId, string title, string author, string genre, int pages, DateTime publishDate, decimal rating, int libraryId, bool available, int timesLent, string description, string coverImg)
        {
            BookId = bookId;
            Title = title;
            Author = author;
            Genre = genre;
            Pages = pages;
            PublishDate = publishDate; 
            Rating = rating;
            LibraryId = libraryId;
            Available = available;
            TimesLent = timesLent;
            Description = description;
            CoverImg = coverImg;
        }

        public Book(string title, string author, string genre, int pages, DateTime publishDate, decimal rating, int libraryId, string description, string coverImg)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Pages = pages;
            PublishDate = publishDate;
            Rating = rating;
            LibraryId = libraryId;
            Description = description;
            CoverImg = coverImg;
        }

        [Key]
        [Column("bookId")]
        public int BookId { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("author")]
        public string Author { get; set; }
        [Column("genre")]
        public string Genre { get; set; }
        [Column("pages")]
        public int Pages { get; set; }
        [Column("publishDate")]
        public DateTime PublishDate { get; set; }
        [Column("rating")]
        public decimal Rating { get; set; }
        [ForeignKey("libraryId")]
        public int LibraryId { get; set; }
        [Column("available")]
        public Boolean Available { get; set; }
        [Column("timesLent")]
        public int TimesLent { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("coverImg")]
        public string CoverImg { get; set; }
    }
}
