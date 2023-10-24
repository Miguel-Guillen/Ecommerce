using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DatabaseContext _context;

    public HomeController(ILogger<HomeController> logger, DatabaseContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Category()
    {
        List<Category> categories = new List<Category> {
            new Category {
                Id = 1,
                Name = "Electrodomesticos",
                Products = 8
            },
            new Category {
                Id = 2,
                Name = "Equipo de Computo",
                Products = 23
            },
            new Category {
                Id = 3,
                Name = "Alimentos y Consumibles",
                Products = 15
            },
            new Category {
                Id = 4,
                Name = "Consolas y Videojuegos",
                Products = 31
            }
        };
        return View(categories);
    }

    [Route("Home/CategoryData/{Id}")]
    public async Task<IActionResult> CategoryData(FilterSeller modal, int Id)
    {
        ViewData["Ids"] = Id;
        var fseller = new FilterSeller()
        {
            Category = "",
            SearchValue = "",
            Data = await _context.Seller.ToListAsync()
        };
        return View(fseller);
    }

    public async Task<IActionResult> Products()
    {
        var listProducts = new FilterProduct() {
            Category = "",
            EnvioGratis = false,
            EnvioInter = false,
            SearchValue = "",
            Data = await _context.Product.ToListAsync()
        };

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
        return View(listProducts);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Products(FilterProduct modal)
    {
        var listProducts = new FilterProduct();
        if(modal.Category != "Seleccionar")
        {
            listProducts = new FilterProduct {
                Category = modal.Category,
                EnvioGratis = modal.EnvioGratis,
                EnvioInter = modal.EnvioInter,
                SearchValue = modal.SearchValue,
                Data = await _context.Product
                .Where(p => p.Category == Convert.ToInt32(modal.Category))
                .ToListAsync()
            };
        }
        if(modal.EnvioGratis != false)
        {
            listProducts = new FilterProduct {
                Category = modal.Category,
                EnvioGratis = modal.EnvioGratis,
                EnvioInter = modal.EnvioInter,
                SearchValue = modal.SearchValue,
                Data = await _context.Product
                .Where(p => p.ShippingType == "Envio Gratis")
                .ToListAsync()
            };
        }
        if(modal.EnvioInter != false)
        {
            listProducts = new FilterProduct {
                Category = modal.Category,
                EnvioGratis = modal.EnvioGratis,
                EnvioInter = modal.EnvioInter,
                SearchValue = modal.SearchValue,
                Data = await _context.Product
                .Where(p => p.ShippingType == "Envio Internacional")
                .ToListAsync()
            };
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
        return View(listProducts);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Search(FilterProduct value){
        return RedirectToAction(nameof(SearchData), value);
    }

    public async Task<IActionResult> SearchData(FilterProduct busqueda){
        ViewData["searchValue"] = busqueda.SearchValue;
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
        
        var listData = new FilterProduct(){
            Category = busqueda.Category,
            EnvioGratis = busqueda.EnvioGratis,
            EnvioInter = busqueda.EnvioInter,
            SearchValue = busqueda.SearchValue,
            Data = await _context.Product
            .Where(p => p.Name.Contains(busqueda.SearchValue))
            .ToListAsync()
        };

        return View(listData);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
