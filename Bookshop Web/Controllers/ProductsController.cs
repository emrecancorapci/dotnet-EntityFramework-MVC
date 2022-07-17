using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookshop.Business.Interfaces;
using Bookshop.Dtos.Requests;
using Bookshop.Dtos.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookshop.Web.Controllers
{
    [Authorize(Roles = "Admin,Editor")]
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var products = await productService.GetProducts();
            products.ToList().Select(p => p.IsActive == true);
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = GetCategoriesForDropdown();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Name", "Price", "Description", "Price", "Discount", "CategoryId", "ImgUrl")]
            AddProductRequest request)
        {
            if (!ModelState.IsValid) return View();

            int addedProductId = await productService.AddProduct(request);
            return RedirectToAction(nameof(Index));
        }

        // TODO 1: Update and Delete processes will be coded.
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (! await productService.IsExist(id)) return NotFound();

            ProductListResponse response = await productService.GetProductById(id);
            ViewBag.Categories = GetCategoriesForDropdown();

            return View(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            [Bind("Id", "Name", "Price", "Description", "Price", "Discount", "CategoryId", "ImgUrl")]
            UpdateProductRequest request)
        {
            if (ModelState.IsValid)
            {
                int affectedRowsCount = await productService.UpdateProduct(request);
                if (affectedRowsCount > 0)
                    return RedirectToAction(nameof(Index));
                return BadRequest();
            }

            // We need to send this to fill the edit page.
            ViewBag.Categories = GetCategoriesForDropdown();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await productService.IsExist(id))
            {
                var product = await productService.GetProductById(id);
                return View(product);
            }

            return NotFound();
        }
        [HttpPost]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> DeletePost(int id)
        {
            await productService.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        private List<SelectListItem> GetCategoriesForDropdown()
        {
            var selectedItems = new List<SelectListItem>();
            categoryService.GetCategories().ToList()
                .ForEach(c => selectedItems.Add(
                    new SelectListItem { Text = c.Title, Value = c.Id.ToString() }
                ));
            return selectedItems;
        }

        
    }

    // TODO 2: Authentication and Authorization will be coded
    // TODO 3: Session system will be explained via checkout processes
}