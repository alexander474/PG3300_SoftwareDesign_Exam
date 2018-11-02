using System;
using System.Threading;
using Faker;
using LottasLopper.Models;

namespace LottasLopper{
  public class Seller : Person{
    public Seller(){
    }

    public override void Action(int actions){
      ModelContext modelContext = new ModelContext();
      for (int i = 0; i < actions; i++){
        Models.Person person = new Models.Person(Faker.Name.FullName(), 0);
        var newProduct = new Product(Faker.Internet.DomainName(), RandomNumber.Next(200, 1000));
        modelContext.Add(newProduct);
        modelContext.SaveChanges();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Seller " + person.Name + 
                          " added product: #" + newProduct.ProductId + " " + newProduct.Name + " for $" + newProduct.Price);
        Thread.Sleep(RandomNumber.Next(1000, 2000));
      }
    }
  }
}
