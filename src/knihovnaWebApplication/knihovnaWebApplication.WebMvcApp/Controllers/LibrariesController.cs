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
        public LibrariesController()
        {
            DbContext = new LibrariesDbContext();
            Libraries = DbContext.Libraries.ToList();
            Users = DbContext.Users.ToList();
        }

        [Authorize] //zabezpeèí jenom konkrétní akci
        public ActionResult BranchDetail(int id)
        {

            string branchName = Libraries.First(l => l.LibraryId == id).Name;
            List<Book> books = DbContext.Books.Where(b => b.LibraryId == id).ToList();

            BranchDetailModel booksBranch = new BranchDetailModel(branchName, books);

            return View(booksBranch);
        }
    }
}
