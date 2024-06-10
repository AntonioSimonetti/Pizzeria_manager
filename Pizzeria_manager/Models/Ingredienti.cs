using System.ComponentModel.DataAnnotations;

namespace Pizzeria_manager.Models
{
    public class Ingredienti
    {
        [Key] public int Id { get; set; }

        public string Name { get; set; }

        public List<Pizza> Pizze { get; set; }
    }
}
