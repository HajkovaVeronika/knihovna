using knihovnaWebApplication.WebMvcApp.Data;
using knihovnaWebApplication.WebMvcApp.Entities;
using knihovnaWebApplication.WebMvcApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using static System.Reflection.Metadata.BlobBuilder;

namespace knihovnaWebApplication.WebMvcApp.Controllers
{
    public class AuthController : Controller
    {
        public LibrariesDbContext DbContext { get; set; }
        public List<User> Users { get; set; }
        public AuthController()
        {
            DbContext = new LibrariesDbContext();
            Users = DbContext.Users.ToList();
        }

        [HttpGet]
        public ActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            //1. zkontroluje jestli uživatel existuje   (name pro inputy musí být stejný jako model.Username atd.)
            User? user = DbContext.Users
                .FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

            if (user == null)
            {
                return View(model); //vrací zpátky login formuláø
            }

            //2. sestavit "identitu/totožnost" uživatele pomocí Claims
            List<Claim> claims = new List<Claim>();

            Claim idClaim = new Claim("id", user.UserId.ToString());  //pod èím se to uloží aby to nemuselo poøád chodit do databáze (?)
            Claim usernameClaim = new Claim("username", user.Username);

            claims.Add(idClaim);
            claims.Add(usernameClaim);

            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme); //vytvoøí identitu uživatele (?)


            //uživatel mùže mít víc identit, napø. když je pøihlášen pøez google nebo discord, musí se vytvoøit principal
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Signup()
        {
            return View(Users);
        }
    }
}
