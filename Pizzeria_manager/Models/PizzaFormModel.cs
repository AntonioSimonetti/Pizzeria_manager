using Microsoft.AspNetCore.Mvc.Rendering;
using Pizzeria_manager.Data;

namespace Pizzeria_manager.Models
{
    public class PizzaFormModel
    {
        public Pizza Pizza {  get; set; }

        public List<Category>? Categories { get; set; }

        public List <SelectListItem>? Ingredienti { get; set; }

        public List<string>? SelectedIngredienti { get; set; }

        public void CreateIngredienti()
        {
            this.Ingredienti = new List<SelectListItem>();
            var ingredientiFromDB = PizzaManager.GetAllIngredienti();
            foreach (var ingredienti in ingredientiFromDB)
            {
                this.Ingredienti.Add(new SelectListItem()
                {
                    Text = ingredienti.Name,
                    Value = ingredienti.Id.ToString(),
                });
            }
        }
    }
}
