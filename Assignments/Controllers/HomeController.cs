using Assignments.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Assignments.Controllers
{
    public class HomeController : Controller
    {
        ShopBIuContext Db = new ShopBIuContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Username") != null)
            {
                var product = Db.TbProducts.ToList();
                return View(product);
            }
            else return RedirectToAction("Dangnhap");

        }
        public IActionResult Dangnhap()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Dangnhap(string Username, string Password)
        {
            if ((Username == "ngocquynh") && (Password == "12345"))
            {
                HttpContext.Session.SetString("Username", "admin");
                return RedirectToAction("Index");
            }
            else return View();
        }

        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult Details()
        {
          TempData["ProductList"] = Db.TbProducts.ToList();
            return View();
        }
        [HttpGet]
        public IActionResult DeleteProduct(int id) 
        {
            ViewData["Category"] = Db.TbCategories.ToList();
            var product = Db.TbProducts.SingleOrDefault(l => l.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName ("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = Db.TbProducts.SingleOrDefault(l => l.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            Db.TbProducts.Remove(product);
            Db.SaveChanges();
            return RedirectToAction("Details");
        }
        public IActionResult EditProduct(int id)
        {
            ViewData["Category"] = Db.TbCategories.ToList();
            var product = Db.TbProducts.SingleOrDefault(l => l.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProduct(TbProduct product)
        {
            if (ModelState.IsValid)
            {
                Db.TbProducts.Update(product);
                Db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View();
        }
        public IActionResult AddProduct()
        {
            ViewData["Category"] = Db.TbCategories.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(TbProduct product)
        {
            if (ModelState.IsValid)
            {
                Db.TbProducts.Add(product);
                Db.SaveChanges();
                return RedirectToAction("Details");
            }
            return RedirectToAction("AddProduct");
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
