using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzeria_manager.Data;
using Pizzeria_manager.Models;
using Microsoft.AspNetCore.Mvc.Rendering;



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
            PizzaFormModel model = new PizzaFormModel();
            model.Pizza = new Pizza();
            model.Categories = PizzaManager.GetAllCategories();
            model.CreateIngredienti();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaFormModel data)
        {
            if (!ModelState.IsValid)
            {
                data.Categories = PizzaManager.GetAllCategories();
                data.CreateIngredienti();
                return View("Create", data);
            }

          

            PizzaManager.InsertPizza(data.Pizza, data.SelectedIngredienti);

            return RedirectToAction("Index");
            
        }

        [HttpGet]

        public IActionResult Update(int id)
        {

            var pizzaToEdit = PizzaManager.GetPizza(id,true);

            if (pizzaToEdit == null)
            {
                return NotFound();
            } 
            else
            {
                PizzaFormModel model = new PizzaFormModel();
                model.Pizza = pizzaToEdit;
                model.Categories = PizzaManager.GetAllCategories();
                return View(model);

            }      
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(int id, PizzaFormModel data)
        {
           if (!ModelState.IsValid)
            {
                //return View("Update", data);

                data.Pizza.Id = id;
                data.Categories = PizzaManager.GetAllCategories(); // Populate Categories when the model is not valid
                return View("Update", data);
            }

            if (PizzaManager.UpdatePizza(id, data.Pizza.Nome, data.Pizza.Descrizione, data.Pizza.FotoUrl, data.Pizza.Prezzo, data.Pizza.CategoryId))
                return RedirectToAction("Index");
            else
                return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (PizzaManager.DeletePizza(id))
                return RedirectToAction("Index");
            else
                return NotFound();
        }
    }
 }

