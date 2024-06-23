using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pizzeria_manager.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pizzeria_manager.Data
{
    internal class PizzaContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Pizza> Pizze { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Ingredienti> Ingredienti { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-3J0361P;Database=pizzaDB;Integrated Security=True;Trust Server Certificate=True");

        }


    }
}


