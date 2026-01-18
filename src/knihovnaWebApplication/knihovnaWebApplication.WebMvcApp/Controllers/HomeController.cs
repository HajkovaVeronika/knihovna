using knihovnaWebApplication.WebMvcApp.Data;
using knihovnaWebApplication.WebMvcApp.Entities;
using knihovnaWebApplication.WebMvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace knihovnaWebApplication.WebMvcApp.Controllers
{
    public class HomeController : Controller
    {
        public LibrariesDbContext DbContext { get; set; }
        public List<Library> Libraries { get; set; }
        public List<Book> Books { get; set; }
        public List<User> Users { get; set; }
       
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            //testuju commit
            _logger = logger;
            DbContext = new LibrariesDbContext();
            Libraries = DbContext.Libraries.ToList();
            Books = DbContext.Books.ToList();
            Users = DbContext.Users.ToList();
        }

        public IActionResult Index()
        {
            return View(Libraries);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
