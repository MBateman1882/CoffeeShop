using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoffeeShop.Models;
using Microsoft.AspNetCore.Http;

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
            ShopDBContext db = new ShopDBContext();

            //loop through Users, and find attached UserItems
            

            //grab user items and add to list
            var userItems = db.UserItems.ToList();

            //db.UserItems.Add(new UserItems() { ItemId = 1, UserId = 3 });
            //db.SaveChanges();
            return View();
        }

        //need one action to load our RegistrationPage, also need a view
        public IActionResult Registration()
        {
            //if no view is specified it defaults to the Action Name
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
            //make a session object as a Key Value pair, value must be string
            //HttpContext.Session.SetString("Funds", value);

            ShopDBContext db = new ShopDBContext();

            Users foundResult = new Users();

            HttpContext.Session.SetString("Registered", "false");

            foreach (Users user in db.Users)
            {
                if (user.UserName == loginUserName && user.Password == loginPassword)
                {
                    foundResult = user;

                    HttpContext.Session.SetString("Registered", "true");

                    //TempData["Funds"] = foundResult.Funds;
                    HttpContext.Session.SetString("Funds", foundResult.Funds.ToString());

                    //to pull value out of string call GetString method
                    //Convert.ToDecimal(HttpContext.Session.GetString("Funds"));
                }
            }

            return View(foundResult);
        }

        public IActionResult Shop()
        {
            ShopDBContext db = new ShopDBContext();

            //TempData["Registered"] = true;

            return View(db);
        }

        public IActionResult Purchase(decimal price)
        {
            ShopDBContext db = new ShopDBContext();

            //TempData["Registered"] = true;

            if (Convert.ToDecimal(HttpContext.Session.GetString("Funds")) - price < 0)
            {
                return View("LowFunds", price);
            }
            else
            {

                return View("Shop", db);
            }
        }

        public IActionResult LowFunds(decimal price)
        {
            ViewBag.Price = "Testing";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
