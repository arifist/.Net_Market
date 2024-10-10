using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public CategoryMenuViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _manager.CategoryService.GetAllCategories(false);
            return View(categories);
        }

    }
}
