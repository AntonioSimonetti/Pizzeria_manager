using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizzeria_manager.Models
{
    [Table("Pizze")] 
    public class Pizza
    {
        [Key] 
        public int Id { get; set; }

        [Column("Nome")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(50, ErrorMessage ="Il nome non può essere piu' lungo di 50 caratteri!")]
        public string Nome { get; set; }

        [Column("Descrizione")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [StringLength(50, ErrorMessage = "La descrizione non può essere piu' lunga di 50 caratteri!")]
        [MinLength(5)]

        public string Descrizione { get; set; }

        [Column("FotoUrl")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string FotoUrl { get; set; }

        [Column("Prezzo")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Range(0.01, 1000, ErrorMessage = "Il prezzo deve essere maggiore di zero.")]
        public float Prezzo { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public Pizza() { }

        public Pizza(string nome, string descrizione, string fotoUrl, float prezzo)
        {
            Nome = nome;
            Descrizione = descrizione;
            FotoUrl = fotoUrl;
            Prezzo = prezzo;
        }

        public string GetDisplayedCategory()
        {
            if (Category == null)
                return "Nessuna categoria";
            return Category.Title;
        }
    }
}

