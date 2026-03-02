using knihovnaWebApplication.WebMvcApp.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace knihovnaWebApplication.WebMvcApp.Models
{
    public class AddBookModel
    {
        public AddBookModel()
        {
        }

        public AddBookModel(string title, string author, string genre, int pages, DateTime publishDate, decimal rating, int libraryId, string description, string coverImg, string libraryName)
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
            LibraryName = libraryName;
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Pages { get; set; }
        public DateTime PublishDate { get; set; }
        public decimal Rating { get; set; }
        public int LibraryId { get; set; }
        public string Description { get; set; }
        public string CoverImg { get; set; }
        public string LibraryName { get; set; }

    }
}
