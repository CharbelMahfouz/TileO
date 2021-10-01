using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TileO.Models;
using Microsoft.AspNetCore.Authorization;
using TileO.ViewModels;

namespace TileO.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly TileoDbContext _context;

        public HomeController(ILogger<HomeController> logger, TileoDbContext context )
        {
            _context = context;
            _logger = logger;
        }
        
        public IActionResult Index()
        {
           
            return View();
        }

      
        public IActionResult BrandsAndCatalog()
        {
            return View();
        }

        public IActionResult AboutUs()
        {

            
            return View();
        }

        public IActionResult Gallery()
        {
           
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

        public IActionResult _Products()
        {
            var products = _context.Products.Where(x => x.IsDeleted == false).Select(x => new Product_VM
            {
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Title = x.Title,
                ProductTypes = (List<ProductType_VM>)x.TilesTypes.Select(y => new ProductType_VM
                {
                    Title = y.Title,
                    ImageUrl = y.ImageUrl,
                    Id = y.Id,
                    ProductId = y.ProductId
                }),

            })
                .ToList();
            return PartialView(products);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
