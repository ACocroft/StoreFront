using Microsoft.AspNetCore.Mvc;
using StoreFront.DATA.EF.Models;
using Microsoft.AspNetCore.Identity;
using StoreFront.UI.MVC.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Storage;

namespace StoreFront.UI.MVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
