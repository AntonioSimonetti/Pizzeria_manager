using Microsoft.EntityFrameworkCore;
using Pizzeria_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria_manager.Data
{
    internal class PizzaContext : DbContext
    {
        public DbSet<Pizza> Pizze { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Ingredienti> Ingredienti { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=pizzaDB;Integrated Security=True;Trust Server Certificate=True");
        }


    }
}
