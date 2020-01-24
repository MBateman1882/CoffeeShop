﻿using System;
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
            return View();
        }

        //need one action to load our RegistrationPage, also need a view
        public IActionResult Registration()
        {
            //if now view is specified it defaults to the Action Name
            return View();
        }

        //need one action to take those user inputs and display the user name in a new view
        public IActionResult Summary (RegistrationPageModel registration)
        {
            // use ViewBag to hold data to be displayed in the View
            //ViewBag.UserName = userName;
            //ViewBag.Email = email;
            //ViewBag.Password = password;

            return View(registration);
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
