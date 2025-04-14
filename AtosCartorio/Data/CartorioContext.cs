using System;
using Microsoft.EntityFrameworkCore;
using AtosCartorio.Models;

namespace AtosCartorio.Data
{
    public class CartorioContext : DbContext
    {
        public DbSet<NascimentoModel> Nascimentos { get; set; }
        public DbSet<CasamentoModel> Casamentos { get; set; }
        public DbSet<ObitoModel> Obitos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=cartorio.db");
    }
}
