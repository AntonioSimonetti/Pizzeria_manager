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
        public string Nome { get; set; }

        [Column("Descrizione")]
        public string Descrizione { get; set; }

        [Column("FotoUrl")]
        public string FotoUrl { get; set; }

        [Column("Prezzo")]
        public float Prezzo { get; set; }

        public Pizza() { }

        public Pizza(string nome, string descrizione, string fotoUrl, float prezzo)
        {
            Nome = nome;
            Descrizione = descrizione;
            FotoUrl = fotoUrl;
            Prezzo = prezzo;
        }
    }
}

