using Microsoft.AspNetCore.Mvc;
using ShoesStoreWebsite.Interfaces;
using ShoesStoreWebsite.Models;

namespace ShoesStoreWebsite.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;

        public CartController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.Get<List<Product_Item>>("cart");
            if (cart != null)
            {
                ViewBag.total = cart.Sum(s => s.Quantity * s.Shoes.Price);
            }
            else
            {
                cart = new List<Product_Item>();
                ViewBag.total = 0;
            }
            return View(cart);
        }

        public IActionResult Buy(int id)
        {
            return RedirectToAction("DeliveryInfo");
        }

        public IActionResult Add(int id)
        {
            var product = _productService.GetShoe(id);
            if (product == null)
            {
                return NotFound();
            }
            var cart = HttpContext.Session.Get<List<Product_Item>>("cart") ?? new List<Product_Item>();

            int index = cart.FindIndex(w => w.Shoes.Id == id);
            if (index != -1)
            {
                cart[index].Quantity++;
            }
            else
            {
                cart.Add(new Product_Item { Shoes = product, Quantity = 1 });
            }
            //cart[index].Quantity++; //increment by 1

            HttpContext.Session.Set<List<Product_Item>>("cart", cart);
            return RedirectToAction("Index");
        }

        public IActionResult Minus(int id)
        {
            var product = _productService.GetShoe(id);
            var cart = HttpContext.Session.Get<List<Product_Item>>("cart");

            int index = cart.FindIndex(w => w.Shoes.Id == id);

            if (cart[index].Quantity == 1) 
            {
                cart.RemoveAt(index);
            }
            else
            {
                cart[index].Quantity--;
            }

            HttpContext.Session.Set<List<Product_Item>>("cart", cart);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var product = _productService.GetShoe(id);
            var cart = HttpContext.Session.Get<List<Product_Item>>("cart");

            int index = cart.FindIndex(w => w.Shoes.Id == id);
            cart.RemoveAt(index);

            HttpContext.Session.Set<List<Product_Item>>("cart", cart);

            return RedirectToAction("Index");
        }
        public IActionResult DeliveryInfo()
        {
            return View();
        }
        public IActionResult ProcessOrder()
        {

            return RedirectToAction("Index", "Home");
        }


    }
}
