﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzeria_manager.Data;
using Pizzeria_manager.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;



namespace Pizzeria_manager.Controllers
{
    [Authorize]
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            return View(PizzaManager.GetAllPizzas());
        }

        [Authorize(Roles = "ADMIN, USER")]
        public IActionResult GetPizza(int id)
        {
            return View("PizzaSingola", PizzaManager.GetPizza(id));
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
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
        [Authorize(Roles = "ADMIN")]

        public IActionResult Create(PizzaFormModel data)
        {
            
            if (!ModelState.IsValid)
            {

                // Log the validation errors
                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    foreach (var error in state.Errors)
                    {
                        Console.WriteLine($"Key: {key}, Error: {error.ErrorMessage}");
                    }
                }

                data.Categories = PizzaManager.GetAllCategories();
                data.CreateIngredienti();
                return View("Create", data);
            } 

            data.SetImageFileFromFormFile();
            PizzaManager.InsertPizza(data.Pizza, data.SelectedIngredienti);

            return RedirectToAction("Index");
            
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]

        public IActionResult Update(int id)
        {

            var pizzaToEdit = PizzaManager.GetPizza(id,true);

            if (pizzaToEdit == null)
            {
                return NotFound();
            } 
            else
            {
                PizzaFormModel model = new PizzaFormModel(pizzaToEdit);
                model.Pizza = pizzaToEdit;
                model.Categories = PizzaManager.GetAllCategories();
                model.CreateIngredienti();
                return View(model);

            }      
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMIN")]

        public IActionResult Update(int id, PizzaFormModel data)
        {
            data.SetImageFileFromFormFile();

            if (!ModelState.IsValid)
            {

                data.Pizza.Id = id;
                data.Categories = PizzaManager.GetAllCategories(); // Populate Categories when the model is not valid
                return View("Update", data);
            }

            if (PizzaManager.UpdatePizza(id, data.Pizza.Nome, data.Pizza.Descrizione, data.Pizza.FotoUrl, data.Pizza.ImageFile, data.Pizza.Prezzo, data.Pizza.CategoryId, data.SelectedIngredienti))
                return RedirectToAction("Index");
            else
                return NotFound();
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMIN")]

        public IActionResult Delete(int id)
        {
            if (PizzaManager.DeletePizza(id))
                return RedirectToAction("Index");
            else
                return NotFound();
        }
    }
 }

