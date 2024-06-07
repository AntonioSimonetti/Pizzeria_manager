using System.ComponentModel.DataAnnotations;

namespace Pizzeria_manager.Models
{
    public class Category
    {
        [Key] public int Id { get; set; }

        public string Title { get; set; }

        public List<Pizza> Pizzas { get; set; }

        public Category() { }

    }
}
