using Microsoft.AspNetCore.Mvc;
using ShoesStoreWebsite.Interfaces;

namespace ShoesStoreWebsite.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetShoes(); //get the list of products
            return View(products); //return to view
        }
    }
}
