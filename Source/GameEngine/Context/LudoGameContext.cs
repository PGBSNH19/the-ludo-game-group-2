using GameEngine.Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Library.Context
{
    class LudoGameContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<GameBoard> GameBoard { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration config = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json", true)
                  .Build();
            
            optionsBuilder.UseSqlServer(config["ConnectionStrings:DefaultConnection"]);

        }
    }
}
