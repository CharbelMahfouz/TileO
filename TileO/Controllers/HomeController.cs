using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TileO.Models;
using Microsoft.AspNetCore.Authorization;

namespace TileO.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static InHealthContext _context;
       
        
        public HomeController(ILogger<HomeController> logger , InHealthContext context)
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

        



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
