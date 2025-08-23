using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(); //Return View Withe Same name of Action
            //return View(new Product()); //Take Model To Bind View With Model Data
            //return Viwe("Test"); //Return View Withe Specific name
            //return Viwe("Test",new Product()); //Return View Withe Specific name and Take Model To Bind View With Model Data 
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
