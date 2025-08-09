using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using ProductMvc.Models;
using ProductMvc.Repositories;

namespace ProductMvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository _repository;
        private readonly ILogger<ProductController> _logger;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public ProductController(IRepository repository, ILogger<ProductController> logger, IStringLocalizer<SharedResource> localizer)
        {
            _repository = repository;
            _logger = logger;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Listing products");
            var products = _repository.GetAllProducts();
            ViewData["Title"] = _localizer["ProductList"];
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.AddProduct(product);
                _logger.LogInformation("Created product {Name}", product.Name);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
    }
}
