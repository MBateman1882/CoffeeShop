using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoffeeShop.Models;

namespace CoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            TempData["Registered"] = false;
            return View();
        }

        //need one action to load our RegistrationPage, also need a view
        public IActionResult Registration()
        {
            //if now view is specified it defaults to the Action Name
            return View();
        }

        public IActionResult MakeNewUser(Users user)
        {
            ShopDBContext db = new ShopDBContext();

            db.Users.Add(user);

            db.SaveChanges();

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        //need one action to take those user inputs and display the user name in a new view
        public IActionResult Summary (string loginUserName, string loginPassword)
        {
            ShopDBContext db = new ShopDBContext();

            Users foundResult = new Users();

            TempData["Registered"] = false;

            foreach (Users user in db.Users)
            {
                if (user.UserName == loginUserName && user.Password == loginPassword)
                {
                    foundResult = user;

                    TempData["Registered"] = true;
                }
            }

            return View(foundResult);
        }

        public IActionResult Shop()
        {
            ShopDBContext db = new ShopDBContext();

            return View(db);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
