using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using Entities.RequestParameters;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index(ProductRequestParameters prp)
        {
            var products=_manager.ProductService.GetAllProductsWithDetails(prp);
            var pagination = new Pagination()
            {
                CurrentPage = prp.PageNumber,
                ItemsPerPage = prp.PageSize,
                TotalItems = _manager.ProductService.GetAllProducts(false).Count()
            };
            return View(new ProductListViewModel() { Products=products,Pagination=pagination });
        }

        public IActionResult Get([FromRoute(Name="id")] int id)
        {
            var model = _manager.ProductService.GetOneProduct(id, false);
            return View(model);
        }

    }
}