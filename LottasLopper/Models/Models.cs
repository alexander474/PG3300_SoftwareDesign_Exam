using Faker;
using Microsoft.EntityFrameworkCore;

namespace LottasLopper.Models{
  public class ModelContext : DbContext{
    public DbSet<Person> Person { get; set; }
    public DbSet<Product> Product { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
      optionsBuilder.EnableSensitiveDataLogging();
      optionsBuilder.UseSqlite("Data Source=testDB.db");
    }
  }

  public class Product{
    public Product(string name, int price){
      Name = name;
      Price = price;
    }

    public Product(){
      Name = Faker.Internet.DomainName();
      Price = RandomNumber.Next(200, 1000);
    }

    public int ProductId{ get; set; }
    public string Name{ get; set; }
    public int Price{ get; set; }
  }
  
  public class Person
  {
    public Person(string name, int money){
      Name = name;
      Money = money;
    }

    public Person(){
      Name = Faker.Name.FullName();
      Money = RandomNumber.Next(50_000, 200_000);
    }

    public int PersonId { get; set; }
    public string Name { get; set; }
    public int Money { get; set; }

  }
}
