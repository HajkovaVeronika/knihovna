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
        public IActionResult BranchDetail(int id)
        {

            string branchName = Libraries.First(l => l.LibraryId == id).Name;       //sequence contains no matching element
            List<Book> books = DbContext.Books.Where(b => b.LibraryId == id).ToList();

            BranchDetailModel booksBranch = new BranchDetailModel(id,branchName, books);

            return View(booksBranch);
        }
        [Authorize]
        public IActionResult BookDetail(int bookId)
        {
            Book book = Books.First(b => b.BookId == bookId);
            return View(book);

        }

        [HttpGet]
        public IActionResult AddBook(int branchId)
        {
            Book book = new Book();
            book.LibraryId = branchId;

            return View(book);
        }

        [HttpPost]
        public IActionResult AddingBook(Book book)  {

            book.Available = true;
            book.TimesLent = 0;
            DbContext.Books.Add(book);
            DbContext.SaveChanges();   


            return RedirectToAction("BookAdded", new { branchId = book.LibraryId }); //todo: musí vrátit i branchId jako model
        }

        public IActionResult BookAdded(int branchId)
        {
            string branchName = Libraries.First(l => l.LibraryId == branchId).Name;
            List<Book> books = DbContext.Books.Where(b => b.LibraryId == branchId).ToList();

            BranchDetailModel booksBranch = new BranchDetailModel(branchId, branchName, books);

            return View("BranchDetail", booksBranch);
        }
    }
}
