using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzeria_manager.Data;
using Pizzeria_manager.Models;


namespace Pizzeria_manager.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            return View(PizzaManager.GetAllPizzas());
        }

        public IActionResult GetPizza(int id)
        {
            return View("PizzaSingola", PizzaManager.GetPizza(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza data)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", data);
            }

            PizzaManager.InsertPizza(data);

            return RedirectToAction("Index");
            
        }
    }
 }

