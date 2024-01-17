using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2_TeamG.Models
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<BasketEntry> BasketEntries { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database=GameShop; TrustServerCertificate=true;Trusted_Connection=true;");
        }
    }
}
