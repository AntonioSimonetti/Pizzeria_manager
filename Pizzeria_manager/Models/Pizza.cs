namespace Pizzeria_manager.Models
{
    public class Pizza
    {
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public string FotoUrl { get; set; }
        public float Prezzo { get; set; }

        public Pizza() { }

        public Pizza(string nome, string descrizione, string fotoUrl, float prezzo)
        {
            this.Nome = nome;
            this.Descrizione = descrizione;
            this.FotoUrl = fotoUrl;
            this.Prezzo = prezzo;
        }
    }
}

