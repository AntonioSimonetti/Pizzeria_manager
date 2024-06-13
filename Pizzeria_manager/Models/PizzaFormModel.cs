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

        public IFormFile? ImageFormFile { get; set; }

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

        public byte[] SetImageFileFromFormFile()
        {
            if (ImageFormFile == null)
                return null;

            using var stream = new MemoryStream();
            this.ImageFormFile?.CopyTo(stream);
            Pizza.ImageFile = stream.ToArray();

            return Pizza.ImageFile;
        }
    }
}
