using Bookshop.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bookshop.Web.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly ICategoryService categoryService;

        public MenuViewComponent(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = this.categoryService.GetCategories();

            return View(categories);
        }
    }
}