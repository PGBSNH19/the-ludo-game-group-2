using GameEngine.Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace GameEngine.Library.Context
{
    public class LudoGameContext : DbContext
    {
        public DbSet<Pawn> Pawns { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pawn>()
                .HasIndex(p => new { p.PawnNumber, p.Color })
                .IsUnique(true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration config = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json", true)
                  .Build();
            
            optionsBuilder.UseSqlServer(config["ConnectionStrings:DefaultConnection"]);
        }
    }
}
