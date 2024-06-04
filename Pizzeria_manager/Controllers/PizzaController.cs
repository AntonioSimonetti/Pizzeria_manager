using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzeria_manager.Models;

namespace Pizzeria_manager.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {

            using (var context = new PizzaContext())
            {

                if (!context.Pizze.Any())
                {

                    Pizza margherita = new Pizza("Margherita", "Pomodoro, Mozzarella, Basilico", "~/img/PizzaMargherita.jpg", 5.5f);
                    Pizza italiana = new Pizza("Italiana", "Rucola, Scaglie di parmiggiano, pomodorini e crudo", "~/img/PizzaRucola.jpg", 7.5f);
                    Pizza croccopizza = new Pizza("Croccopizza", "Crocche e mozzarella, cotto e panna", "~/img/PizzaCroccoPizza.jpg", 8f);
                    Pizza salsiccia = new Pizza("Salsiccia e Patatine", "Salsiccia, patatine fritte, mozzarella", "~/img/PizzaSalsiccia.jpg", 8.5f);
                    Pizza friarelli = new Pizza("Salsiccia e friarielli", "Salsiccia, friarielli, mozzarella", "~/img/PizzaFriarielli.jpg", 7f);

                    context.Pizze.Add(margherita);
                    context.Pizze.Add(italiana);
                    context.Pizze.Add(croccopizza);
                    context.Pizze.Add(salsiccia);
                    context.Pizze.Add(friarelli);

                    context.SaveChanges();
                }
                List<Pizza> pizze = context.Pizze.ToList();

                //Se vuoi testare "on the fly" cosa succede se non vengono passati dati al model dal db, come reagisce la view
                //List<Pizza> pizzeToFail = new List<Pizza>();

                return View(pizze);
            }



        }

        public IActionResult GetPizza(int id)
        {

            using (var context = new PizzaContext())
            {

                Pizza pizza = context.Pizze.FirstOrDefault(p => p.Id == id);

                if (pizza == null)
                {
                    return NotFound();
                }

                return View("PizzaSingola", pizza);
            }
        }
    }
}
