/*
using Pizzeria_manager.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace Pizzeria_manager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Aggiunge il DbContext per l'accesso ai dati
            builder.Services.AddDbContext<PizzaContext>();

            // Configura l'identità predefinita con autenticazione e gestione dei ruoli
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>() // Aggiunge il supporto per i ruoli
                .AddEntityFrameworkStores<PizzaContext>();

            // Configura i servizi per MVC e le opzioni JSON
            builder.Services.AddControllersWithViews();
            builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            // Configura l'autenticazione JWT
            var jwtSettings = builder.Configuration.GetSection("Jwt");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);
            // Sostituisci con una chiave segreta sicura
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true, // Valida il nome dell'emittente (issuer)
                    ValidateAudience = true, // Valida il destinatario (audience)
                    ValidateIssuerSigningKey = true, // Valida la chiave di firma dell'emittente
                    ValidIssuer = jwtSettings["Issuer"], 
                    ValidAudience = jwtSettings["Audience"],
                    //ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    //ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            // Configura le politiche CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:5173")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });

                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            // Configura il middleware per le richieste HTTP
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
                app.UseCors("AllowSpecificOrigins");
            }
            else
            {
                app.UseCors("AllowAll");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication(); // Abilita l'autenticazione
            app.UseAuthorization(); // Abilita l'autorizzazione

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
*/

using Pizzeria_manager.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Pizzeria_manager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Aggiunge il DbContext per l'accesso ai dati
            builder.Services.AddDbContext<PizzaContext>();

            // Configura l'identità predefinita con autenticazione e gestione dei ruoli
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>() // Aggiunge il supporto per i ruoli
                .AddEntityFrameworkStores<PizzaContext>();

            // Configura i servizi per MVC e le opzioni JSON
            builder.Services.AddControllersWithViews();
            builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            // Configura l'autenticazione JWT

            // Ottiene la configurazione della sezione JWT
            var jwtSettings = builder.Configuration.GetSection("Jwt");

            // Ottiene la chiave dalla variabile d'ambiente JWT_KEY, se non esiste, usa la chiave dal file di configurazione
            var key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("JWT_KEY") ?? jwtSettings["Key"]);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true, // Valida il nome dell'emittente (issuer)
                    ValidateAudience = true, // Valida il destinatario (audience)
                    ValidateIssuerSigningKey = true, // Valida la chiave di firma dell'emittente
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key) // Usa la chiave ottenuta
                };
            });

            // Configura le politiche CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:5173")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });

                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            // Configura il middleware per le richieste HTTP
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
                app.UseCors("AllowSpecificOrigins");
            }
            else
            {
                app.UseCors("AllowAll");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication(); // Abilita l'autenticazione
            app.UseAuthorization(); // Abilita l'autorizzazione

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
