using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            using(Models.AppContext context = new Models.AppContext())
            {
                context.AddRange(new UserModel[]
                {
                    new UserModel
                    {
                        Name = "Александр",
                        Balance = 543.2,
                        Created = DateTime.ParseExact("2005-05-05 22:12", "yyyy-MM-dd HH:mm",null)
                    },
                    new UserModel
                    {
                        Name = "Виталий",
                        Balance = 543232.26,
                        Created = DateTime.ParseExact("2010-11-11 15:12", "yyyy-MM-dd HH:mm",null)
                    },
                    new UserModel
                    {
                        Name = "Константин",
                        Balance = 21,
                        Created = DateTime.ParseExact("2070-01-25 15:12", "yyyy-MM-dd HH:mm",null)
                    }
                });
                context.SaveChanges();
            }
        }

        public IActionResult Index()
        {
            List<UserModel> users = new List<UserModel>();
            using(Models.AppContext context = new Models.AppContext())
            {
                users = context.Users.ToList();
            }
            return View(users);
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
