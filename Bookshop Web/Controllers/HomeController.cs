using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bookshop.Entities;
using Bookshop.Web.Models;
using Bookshop.Business.Interfaces;

namespace Bookshop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Index(int page=1, int? catId=0)
        {
            int productsPerPage = 3;
            var productsFromService = await _productService.GetProducts();

            var products = catId == 0 ?  
                productsFromService :
                productsFromService.Where(p=> p.CategoryId == catId).ToList();

            var paginatedProducts = products
                .OrderBy(x => x.Id)
                .Skip((page - 1) * productsPerPage)
                .Take(productsPerPage);

            ViewBag.TotalPage = Math.Ceiling((decimal)products.Count / productsPerPage);

            ViewBag.Category = catId;
            ViewBag.CurrentPage = page;

            return View(paginatedProducts);
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
