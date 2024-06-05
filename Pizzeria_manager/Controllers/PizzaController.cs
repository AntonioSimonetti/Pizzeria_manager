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
    }
 }

