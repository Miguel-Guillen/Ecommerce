using Ecommerce.Models;
using Ecommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly DatabaseContext _context;

        public DashboardController(ILogger<DashboardController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddSeller()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSeller(SellerVM modal)
        {
            if (ModelState.IsValid)
            {
                var seller = new Seller()
                {
                    Id = 0,
                    Name = modal.Name,
                    LastName = modal.LastName,
                    Address = modal.Address,
                    Cellphone = modal.Cellphone,
                    City = modal.City,
                    Email = modal.Email,
                    Password = modal.Password,
                    Date = DateTime.Now
                };

                _context.Seller.Add(seller);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AddSeller));
            }

            return View();
        }

        public async Task<IActionResult> AddProduct()
        {
            List<Category> categories = new List<Category> {
                new Category {
                    Id = 1,
                    Name = "Electrodomesticos"
                },
                new Category {
                    Id = 2,
                    Name = "Equipo de Computo"
                },
                new Category {
                    Id = 3,
                    Name = "Alimentos y Consumibles"
                },
                new Category {
                    Id = 4,
                    Name = "Consolas y Videojuegos"
                }
            };
            ViewData["Category"] = new SelectList(categories, "Id", "Name");
            var shipping = new List<object> {
                new { 
                    Id = "Envio gratis",
                    Name = "Envio gratis"
                },
                new{
                    Id = "Comercio internacional",
                    Name = "Comercio internacional"
                }
            };
            ViewData["ShippingType"] = new SelectList(shipping, "Id", "Name");
            var sellers = await _context.Seller.ToListAsync();
            ViewData["Sellers"] = new SelectList(sellers, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(ProductVM modal)
        {
            if (ModelState.IsValid && modal.ShippingType != "Seleccionar")
            {
                var product = new Product()
                {
                    Id = 0,
                    Name = modal.Name,
                    Description = modal.Description,
                    Category = modal.Category,
                    SellerId = modal.SellerId,
                    Cost = modal.Cost,
                    Discount = modal.Discount,
                    Stock = modal.Stock,
                    ShippingType = modal.ShippingType,
                    Date = DateTime.Now,
                    Img = modal.Img
                };

                _context.Product.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AddProduct));
            }

            List<Category> categories = new List<Category> {
                new Category {
                    Id = 1,
                    Name = "Electrodomesticos"
                },
                new Category {
                    Id = 2,
                    Name = "Equipo de Computo"
                },
                new Category {
                    Id = 3,
                    Name = "Alimentos y Consumibles"
                },
                new Category {
                    Id = 4,
                    Name = "Consolas y Videojuegos"
                }
            };
            ViewData["Category"] = new SelectList(categories, "Id", "Name");
            var shipping = new List<object> {
                new { 
                    Id = "Envio gratis",
                    Name = "Envio gratis"
                },
                new{
                    Id = "Comercio internacional",
                    Name = "Comercio internacional"
                }
            };
            ViewData["ShippingType"] = new SelectList(shipping, "Id", "Name");
            var sellers = await _context.Seller.ToListAsync();
            ViewData["Sellers"] = new SelectList(sellers, "Id", "Name");

            return View(modal);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}