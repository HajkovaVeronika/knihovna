using knihovnaWebApplication.WebMvcApp.Data;
using knihovnaWebApplication.WebMvcApp.Entities;
using knihovnaWebApplication.WebMvcApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Reflection.Metadata.BlobBuilder;

namespace knihovnaWebApplication.WebMvcApp.Controllers
{
    //[Authorize] //zabespeèí se celej controller a jeho akce
    public class LibrariesController : Controller
    {
        public LibrariesDbContext DbContext { get; set; }
        public List<Library> Libraries { get; set; }
        public List<User> Users { get; set; }
        public List<Book> Books { get; set; }
        public LibrariesController()
        {
            DbContext = new LibrariesDbContext();
            Libraries = DbContext.Libraries.ToList();
            Users = DbContext.Users.ToList();
            Books = DbContext.Books.ToList();
        }

        //[Authorize] //zabezpeèí jenom konkrétní akci
        public IActionResult BranchDetail(int libraryId)
        {

            string branchName = Libraries.First(l => l.LibraryId == libraryId).Name;
            List<Book> books = DbContext.Books.Where(b => b.LibraryId == libraryId).ToList();

            BranchDetailModel booksBranch = new BranchDetailModel(libraryId, branchName, books);

            return View(booksBranch);
        }

        public IActionResult BookDetail(int bookId)
        {
            Book book = Books.First(b => b.BookId == bookId);

            BookDetailModel model = new BookDetailModel(book.LibraryId, Libraries.First(l => l.LibraryId == book.LibraryId).Name, book);

            return View(model);

        }

        [Authorize]
        [HttpGet]
        public IActionResult AddBook(int branchId)
        {
            AddBookModel book = new AddBookModel();
            book.LibraryId = branchId;
            //book.LibraryName = Libraries.First(l => l.LibraryId == branchId);

            return View(book);
        }

        [HttpPost]
        public IActionResult AddingBook(AddBookModel bookModel)
        {
            Book book = new Book(bookModel.Title, bookModel.Author, bookModel.Genre, bookModel.Pages, bookModel.PublishDate, bookModel.Rating, bookModel.LibraryId, bookModel.Description, bookModel.CoverImg);

            book.Available = true;
            book.TimesLent = 0;
            DbContext.Books.Add(book);
            DbContext.SaveChanges();


            return RedirectToAction("BookAdded", new { branchId = book.LibraryId });
        }

        public IActionResult BookAdded(int branchId)
        {
            string branchName = Libraries.First(l => l.LibraryId == branchId).Name;
            List<Book> books = DbContext.Books.Where(b => b.LibraryId == branchId).ToList();

            BranchDetailModel booksBranch = new BranchDetailModel(branchId, branchName, books);

            return View("BranchDetail", booksBranch);
        }

        [Authorize]
        public IActionResult deleteBook(int bookId)
        {
            Book book = Books.First(b => b.BookId == bookId);
            int branchId = book.LibraryId;
            DbContext.Books.Remove(book);
            DbContext.SaveChanges();

            string branchName = Libraries.First(l => l.LibraryId == branchId).Name;
            List<Book> books = DbContext.Books.Where(b => b.LibraryId == branchId).ToList();

            BranchDetailModel booksBranch = new BranchDetailModel(branchId, branchName, books);

            return View("BranchDetail", booksBranch);
        }

        [Authorize]
        public IActionResult EditBook(int bookId)
        {
            Book book = Books.First(b => b.BookId == bookId);
            return View(book);
        }

        [HttpPost]
        public IActionResult EditingBook(Book book)
        {
            Book bookToEdit = Books.First(b => b.BookId == book.BookId);
            bookToEdit.CoverImg = book.CoverImg;
            bookToEdit.Title = book.Title;
            bookToEdit.Author = book.Author;
            bookToEdit.Genre = book.Genre;
            bookToEdit.Pages = book.Pages;
            bookToEdit.PublishDate = book.PublishDate;
            bookToEdit.Rating = book.Rating;
            bookToEdit.Description = book.Description;
            bookToEdit.Available = book.Available;
            bookToEdit.TimesLent = book.TimesLent;
            DbContext.SaveChanges();

            BookDetailModel model = new BookDetailModel(book.LibraryId, Libraries.First(l => l.LibraryId == book.LibraryId).Name, book);
            return View("BookDetail", model);
        }
    }
}
