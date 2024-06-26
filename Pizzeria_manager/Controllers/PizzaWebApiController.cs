﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizzeria_manager.Data;
using Pizzeria_manager.Models;

namespace Pizzeria_manager.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaWebApiController : ControllerBase
    {
        [HttpGet("{name?}")]
        [Authorize(Roles = "ADMIN,USER")]
        public IActionResult GetAllPizzas(string? name = "")
        {
            if (string.IsNullOrWhiteSpace(name))
                return Ok(PizzaManager.GetAllPizzas());

            return Ok(PizzaManager.GetPizzasByName(name));
        }

        [HttpGet("{nome}")]
        public IActionResult GetPizzaByName(string nome)
        {
            var pizza = PizzaManager.GetPizzaByName(nome);
            if (pizza == null)
                return NotFound();
            return Ok(pizza);
        }

        [HttpGet("{nome}")]
        public IActionResult GetPizzaByNamePartial(string nome)
        {
            var pizzas = PizzaManager.GetPizzasByNamePartial(nome);
            if (!pizzas.Any())
                return NotFound();
            return Ok(pizzas);
        }


        [HttpGet]
        public IActionResult GetPizzaById(int id)
        {
            var pizza = PizzaManager.GetPizza(id, true);
            if (pizza == null)
                return NotFound();
            return Ok(pizza);
        }

        [HttpPost]
        public IActionResult InsertPizza([FromBody] Pizza pizza)
        {
            Console.WriteLine("ciao");
            PizzaManager.InsertPizza(pizza, null);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePizza(int id, [FromBody] Pizza pizza)
        {
            var oldPizza = PizzaManager.GetPizza(id);
            if (oldPizza == null)
                return NotFound();
            pizza.Id = id;
           
            var selectedIngredienti = pizza.Ingredienti?.Select(i => i.Id.ToString()).ToList();

            PizzaManager.UpdatePizza(pizza.Id, pizza.Nome, pizza.Descrizione, pizza.FotoUrl, pizza.ImageFile, pizza.Prezzo, pizza.CategoryId, selectedIngredienti);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]

        public IActionResult DeletePizza(int id)
        {
            bool found = PizzaManager.DeletePizza(id);
            if (found)
                return Ok();
            return NotFound();
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN,USER")]
        public IActionResult GetAllCategories()
        {
            return Ok(PizzaManager.GetAllCategories());
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN,USER")]
        public IActionResult GetAllIngredienti()
        {
            return Ok(PizzaManager.GetAllIngredienti());
        }

    }
}
