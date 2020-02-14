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

        //these private fields will be used as a way to load in the user and item data
        private List<Items> itemList;
        private List<Users> userList;
        //private ShopDBContext db;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            GetData();
        }

        public IActionResult Index()
        {
            //var x = db.UserItems.Where(userItems => userItems.UserId == 1).ToList();

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

        public IActionResult Summary (string loginUserName, string loginPassword)
        {
            ShopDBContext db = new ShopDBContext();

            Users foundResult = new Users();

            HttpContext.Session.SetString("Registered", "false");

            foreach (Users user in db.Users)
            {
                if (user.UserName == loginUserName && user.Password == loginPassword)
                {
                    foundResult = user;

                    HttpContext.Session.SetString("Registered", "true");
                    HttpContext.Session.SetString("Funds", foundResult.Funds.ToString());
                    HttpContext.Session.SetString("User", foundResult.UserName.ToString());
                    HttpContext.Session.SetString("Id", foundResult.Id.ToString());
                }
            }

            return View(foundResult);
        }

        public IActionResult Shop()
        {
            ShopDBContext db = new ShopDBContext();

            return View(db);
        }

        public IActionResult Purchase(decimal price, string name)
        {
            ShopDBContext db = new ShopDBContext();
            Users currentUser = new Users();
            Items boughtItem = new Items();

            foreach(Users user in db.Users)
            {
                if (user.UserName == HttpContext.Session.GetString("User"))
                {
                    currentUser = user;
                }
            }

            if (currentUser.Funds - price < 0)
            {
                return View("LowFunds", currentUser);
            }
            else
            {
                foreach (Items item in db.Items)
                {
                    if (item.Name == name)
                    {
                        boughtItem = item;
                        boughtItem.Quantity -= 1;
                        currentUser.Funds -= price;

                        db.UserItems.Add(new UserItems { UserId = currentUser.Id, ItemId = boughtItem.Id });
                    }
                }

                db.SaveChanges();

                return View("Shop", db);
            }
        }

        public IActionResult AddInventory(string name)
        {
            ShopDBContext db = new ShopDBContext();
            Items supplyItem = new Items();

            foreach (Items item in db.Items)
            {
                if (item.Name == name)
                {
                    supplyItem = item;
                    supplyItem.Quantity += 1;
                }
            }
            db.SaveChanges();

            return View("Shop", db);
        }

        public IActionResult LowFunds(decimal price)
        {
            ViewBag.Price = price;
            return View();
        }

        public IActionResult List()
        { 
            ShopDBContext db = new ShopDBContext();

            return View(db);
        }

        public IActionResult Details(int id)
        {
            ShopDBContext db = new ShopDBContext();
            Items foundItem = new Items();

            foreach(Items item in db.Items)
            {
                if(item.Id == id)
                {
                    foundItem = item;
                }
            }
            return View(foundItem);
        }

        public IActionResult Delete(int id)
        {
            ShopDBContext db = new ShopDBContext();
            UserItems foundItem = new UserItems();

            foreach(UserItems item in db.UserItems)
            {
                if(item.UserItemId == id)
                {
                    foundItem = item;
                }
            }

            db.UserItems.Remove(foundItem);
            db.SaveChanges();

            return View("List", db);
        }

        //this method will load in my DB data
        private void GetData()
        {
            ShopDBContext db = new ShopDBContext();
            //call the items table and pull in the data to hold in our private field
            //first called the items table
            itemList = db.Items.ToList();
            //now call the users table
            userList = db.Users.ToList();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
