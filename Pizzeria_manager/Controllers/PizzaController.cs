﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]

        public IActionResult Update(int id)
        {
            using (PizzaContext context = new PizzaContext())
            {
                var pizzaToEdit = PizzaManager.GetPizza(id);

                if(pizzaToEdit == null)
                {
                    return NotFound();
                } else
                {
                    return View(pizzaToEdit);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(int id, Pizza data)
        {
           if (!ModelState.IsValid)
            {
                return View("Update", data);
            }

            if (PizzaManager.UpdatePizza(id, data.Nome, data.Descrizione, data.FotoUrl, data.Prezzo))
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

