using Microsoft.AspNetCore.Mvc;
using StoreFront.DATA.EF.Models; //Grants access to the context and Product classes
using Microsoft.AspNetCore.Identity; //Grants access to the UserManager class
using StoreFront.UI.MVC.Models; //Grants access to the CartItemViewModel class
using Newtonsoft.Json; //Allows for easier management of the shopping cart
using Microsoft.EntityFrameworkCore.Storage;
using StoreFront.DATA.EF.Models;
using StoreFront.UI.MVC.Models;

namespace StoreFront.UI.MVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly UndeadBurgGeneralContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ShoppingCartController(UndeadBurgGeneralContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            
            var sessionCart = HttpContext.Session.GetString("cart");

            
            Dictionary<int, CartItemViewModel> shoppingCart = null;

            
            if (sessionCart == null || sessionCart.Count() == 0)
            {
                
                shoppingCart = new Dictionary<int, CartItemViewModel>();

                ViewBag.Message = "There are no items in your cart.";
            }
            else
            {
                ViewBag.Message = null;

                
                shoppingCart = JsonConvert.DeserializeObject<Dictionary<int, CartItemViewModel>>(sessionCart);
            }

            return View(shoppingCart);
        }

        public IActionResult AddToCart(int id)
        {
            
            Dictionary<int, CartItemViewModel> shoppingCart = null;

            var sessionCart = HttpContext.Session.GetString("cart");

            
            if (String.IsNullOrEmpty(sessionCart))
            {
                
                shoppingCart = new Dictionary<int, CartItemViewModel>();
            }
            else
            {
                
                shoppingCart = JsonConvert.DeserializeObject<Dictionary<int, CartItemViewModel>>(sessionCart);
            }

            
            Ware ware = _context.Wares.Find(id);

            
            CartItemViewModel civm = new CartItemViewModel(1, ware);

            
            if (shoppingCart.ContainsKey(ware.WaresId))
            {
                
                shoppingCart[ware.WaresId].Qty++;
            }
            else
            {
                
                shoppingCart.Add(ware.WaresId, civm);
            }

            
            string jsonCart = JsonConvert.SerializeObject(shoppingCart);
            HttpContext.Session.SetString("cart", jsonCart);

            return RedirectToAction("Index");
        }


        public IActionResult RemoveFromCart(int id)
        {
            
            var sessionCart = HttpContext.Session.GetString("cart");

            
            Dictionary<int, CartItemViewModel> shoppingCart = JsonConvert.DeserializeObject<Dictionary<int, CartItemViewModel>>(sessionCart);

            
            shoppingCart.Remove(id);

            
            if (shoppingCart.Count == 0)
            {
                HttpContext.Session.Remove("cart");
            }
            else
            {
                
                string jsonCart = JsonConvert.SerializeObject(shoppingCart);
                HttpContext.Session.SetString("cart", jsonCart);
            }

            return RedirectToAction("Index");
        }


        public IActionResult UpdateCart(int productId, int qty)
        {
            
            var sessionCart = HttpContext.Session.GetString("cart");

            
            Dictionary<int, CartItemViewModel> shoppingCart = JsonConvert.DeserializeObject<Dictionary<int, CartItemViewModel>>(sessionCart);

            
            shoppingCart[productId].Qty = qty;

            
            string jsonCart = JsonConvert.SerializeObject(shoppingCart);
            HttpContext.Session.SetString("cart", jsonCart);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> SubmitOrder()
        {
            
            string? userId = (await _userManager.GetUserAsync(HttpContext.User))?.Id;

            
            UserDetail ud = _context.UserDetails.Find(userId);

            
            Order o = new Order()
            {
                OrderDate = DateTime.Now,
                CustomerId = ud.UserId,
                //CustomerName = ud.UserName,
                //City = ud.City,
                //Country = ud.Country
            };

            
            _context.Orders.Add(o);

            
            var sessionCart = HttpContext.Session.GetString("cart");

            
            Dictionary<int, CartItemViewModel> shoppingCart = JsonConvert.DeserializeObject<Dictionary<int, CartItemViewModel>>(sessionCart);

            
            foreach (var item in shoppingCart)
            {
                OrderWare ow = new OrderWare()
                {
                    OrderId = o.OrderId,
                    WaresId = item.Key,
                    Price = item.Value.Ware.Price,
                    Quantity = (short)item.Value.Qty
                };

                
                o.OrderWares.Add(ow);
            }

            
            _context.SaveChanges();

            
            return RedirectToAction("Index", "Orders");

        }

    }
}
