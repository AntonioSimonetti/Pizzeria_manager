using Microsoft.AspNetCore.Authorization;
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
            if(string.IsNullOrWhiteSpace(name))
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
            //PizzaManager.UpdatePizza(pizza.Id, pizza.Nome, pizza.Descrizione, pizza.FotoUrl, pizza.Prezzo, pizza.CategoryId, null);

            PizzaManager.UpdatePizza(pizza.Id, pizza.Nome, pizza.Descrizione, pizza.FotoUrl, pizza.ImageFile, pizza.Prezzo, pizza.CategoryId, null);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePizza(int id)
        {
            bool found = PizzaManager.DeletePizza(id);
            if (found)
                return Ok();
            return NotFound();
        }
    }
}
