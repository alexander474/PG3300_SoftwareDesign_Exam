using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LottasLopper.Product
{
  public class ProductContext : DbContext
  {
    public DbSet<Product> Product { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=lottasDB.db");
    }
  }

  public class Product
  {
    public Product(string name){
      Name = name;
    }

    public int ProductId { get; set; }
    public string Name { get; set; }

//    public Owner Owner { get; set; }
  }
}
