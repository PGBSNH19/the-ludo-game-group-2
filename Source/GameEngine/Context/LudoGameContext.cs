using GameEngine.Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Library.Context
{
    public class LudoGameContext : DbContext
    {
        public DbSet<Pawn> Pawns { get; set; }
        public DbSet<User> Users { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration config = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json", true)
                  .Build();
            
            optionsBuilder.UseSqlServer(config["ConnectionStrings:DefaultConnection"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pawn>()
                .HasIndex(p => new { p.PawnColorID, p.Color})
                .IsUnique(true);
        }
    }
}
