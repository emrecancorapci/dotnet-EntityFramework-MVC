using Bookshop.Business.Interfaces;
using Bookshop.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshop.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService productService;

        public CartController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult Index()
        {
            var cartCollection = GetCollectionFromSession();
            return View(cartCollection);
        }

        public async Task<IActionResult> Add(int id)
        {
            if (await productService.IsExist(id))
            {
                var product = await productService.GetProductById(id);
                CartCollection cartCollection = GetCollectionFromSession();
                cartCollection
                    .Add(new CartItem
                    {
                        Product = product,
                        Quantity = 1
                    });
                SaveCollectionToSession(cartCollection);

                return Json($"{product.Name} added to cart.");
            }

            return NotFound();
        }

        public async Task<IActionResult> Remove(int id)
        {
            if (!await productService.IsExist(id)) return NotFound();
            
            var product = await productService.GetProductById(id);
            
            CartCollection cartCollection = GetCollectionFromSession();
            cartCollection.Delete(id);
            
            SaveCollectionToSession(cartCollection);
            
            return Json($"{product.Name} removed from cart.");
        }

        public IActionResult Clear()
        {
            CartCollection cartCollection = GetCollectionFromSession();
            cartCollection.ClearAll();
            SaveCollectionToSession(cartCollection);
            return Json("Cart cleared.");
        }

        public IActionResult Checkout()
        {
            return View();
        }
        
        private CartCollection GetCollectionFromSession()
        {
            var session = HttpContext.Session.GetString(nameof(CartCollection));

            CartCollection cartCollection = (session == null) ? new CartCollection()
                : JsonConvert.DeserializeObject<CartCollection>(session);

            return cartCollection;
        }

        private void SaveCollectionToSession(CartCollection cartCollection)
        {
            HttpContext.Session.SetString(nameof(CartCollection), JsonConvert.SerializeObject(cartCollection));
        }
    }
}
