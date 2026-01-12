using System.Diagnostics;
using knihovnaWebApplication.WebMvcApp.Data;
using knihovnaWebApplication.WebMvcApp.Entities;
using knihovnaWebApplication.WebMvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace knihovnaWebApplication.WebMvcApp.Controllers
{
    public class LibrariesController : Controller
    {
        public LibrariesDbContext DbContext { get; set; }
        public List<Library> Libraries { get; set; }
        public List<Book> Books { get; set; }
        public List<User> Users { get; set; }
        public LibrariesController()
        {
            DbContext = new LibrariesDbContext();
            Libraries = DbContext.Libraries.ToList();
            Books = DbContext.Books.ToList();
            Users = DbContext.Users.ToList();
        }

        public IActionResult List()
        {
            return View(Libraries);
        }
    }
}
