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

    public IActionResult Catalogue()
    {
        return View();
    }

    public async Task<IActionResult> Products()
    {
        var listProducts = new FilterProduct() {
            Category = "",
            EnvioGratis = false,
            EnvioInter = false,
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
