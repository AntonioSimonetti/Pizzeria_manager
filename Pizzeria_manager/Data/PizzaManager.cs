using Microsoft.EntityFrameworkCore;
using Pizzeria_manager.Models;

namespace Pizzeria_manager.Data
{
    public static class PizzaManager
    {
        public static int CountAllPizzas()
        {
            using PizzaContext db = new PizzaContext();
            return db.Pizze.Count();
        }

        public static List<Pizza> GetAllPizzas()
        {
            using PizzaContext db = new PizzaContext();
            return db.Pizze.ToList();
        }

        public static Pizza GetPizza(int id, bool includeReferences = true)
        {
            using PizzaContext db = new PizzaContext();
            if(includeReferences)
                 return db.Pizze.Where(p => p.Id == id).Include(p => p.Category).FirstOrDefault();
            return db.Pizze.FirstOrDefault(p => p.Id == id);
        }

        public static void InsertPizza(Pizza pizza)
        {
            using PizzaContext db = new PizzaContext();
            db.Pizze.Add(pizza);
            db.SaveChanges();
        }

        public static bool UpdatePizza(int id, string nome, string descrizione, string fotoUrl, float prezzo, int? categoryId)
        {
            using PizzaContext context = new PizzaContext();
            var pizza = context.Pizze.FirstOrDefault(p => p.Id == id);

                if(pizza == null)
                    return false;
                

                pizza.Nome = nome;
                pizza.Descrizione = descrizione;
                pizza.FotoUrl = fotoUrl;
                pizza.Prezzo = prezzo;
                pizza.CategoryId = categoryId;

                context.SaveChanges();

                return true;
            
        }

        public static bool DeletePizza(int id)
        {
            using PizzaContext context = new PizzaContext();
            var pizza = context.Pizze.FirstOrDefault(p => p.Id == id);

            if (pizza == null)
                return false;


            context.Pizze.Remove(pizza);
            context.SaveChanges();

            return true;
        }

        public static List<Category> GetAllCategories()
        {
            using PizzaContext db = new PizzaContext();
            return db.Categories.ToList();
        }

        public static void Seed()
        {
            if (PizzaManager.CountAllPizzas() == 0)
            {

                Pizza margherita = new Pizza("Margherita", "Pomodoro, Mozzarella, Basilico", "~/img/PizzaMargherita.jpg", 5.5f);
                Pizza italiana = new Pizza("Italiana", "Rucola, Scaglie di parmiggiano, pomodorini e crudo", "~/img/PizzaRucola.jpg", 7.5f);
                Pizza croccopizza = new Pizza("Croccopizza", "Crocche e mozzarella, cotto e panna", "~/img/PizzaCroccoPizza.jpg", 8f);
                Pizza salsiccia = new Pizza("Salsiccia e Patatine", "Salsiccia, patatine fritte, mozzarella", "~/img/PizzaSalsiccia.jpg", 8.5f);
                Pizza friarelli = new Pizza("Salsiccia e friarielli", "Salsiccia, friarielli, mozzarella", "~/img/PizzaFriarielli.jpg", 7f);

                PizzaManager.InsertPizza(margherita);
                PizzaManager.InsertPizza(italiana);
                PizzaManager.InsertPizza(croccopizza);
                PizzaManager.InsertPizza(salsiccia);
                PizzaManager.InsertPizza(friarelli);

            }
        }
    }
}
