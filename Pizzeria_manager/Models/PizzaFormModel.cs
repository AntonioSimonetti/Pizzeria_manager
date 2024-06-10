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

        public PizzaFormModel() { }

        public PizzaFormModel(Pizza pizza)
        {
            this.Pizza = pizza;
            this.SelectedIngredienti = this.Pizza.Ingredienti.Select(x => x.Id.ToString()).ToList();
        }

        public void CreateIngredienti()
        {
            this.Ingredienti = new List<SelectListItem>();
            if(this.SelectedIngredienti == null)
                this.SelectedIngredienti = new List<string>();
            var ingredientiFromDB = PizzaManager.GetAllIngredienti();
            foreach (var ingredienti in ingredientiFromDB)
            {
                bool isSelected = this.SelectedIngredienti.Contains(ingredienti.Id.ToString());
                this.Ingredienti.Add(new SelectListItem()
                {
                    Text = ingredienti.Name,
                    Value = ingredienti.Id.ToString(),
                    Selected = isSelected   
                });
        
            }
        }
    }
}
