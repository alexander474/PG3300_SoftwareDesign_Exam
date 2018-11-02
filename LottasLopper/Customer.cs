using System;
using System.Linq;
using System.Threading;
using Faker;
using LottasLopper.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace LottasLopper{
  public class Customer : Person{
    public override void Action(int actions){
      ModelContext modelContext = new ModelContext();
      Models.Person person = new Models.Person(Faker.Name.FullName(), RandomNumber.Next(5_000, 10_000));
      modelContext.Add(person);
      while (person.Money > 0 || modelContext.Product.Any()){
        var randomProduct = new ProductController().getRandomProduct();
        if(randomProduct == null) continue;
        try{
          lock (randomProduct){
            modelContext.Remove(randomProduct);
            try{
              if (modelContext.SaveChanges() > 1 && person.Money > randomProduct.Price){
                person.Money -= randomProduct.Price;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(person.Name + " bought product #" + randomProduct.ProductId + " " +
                                  randomProduct.Name + " for $" +
                                  randomProduct.Price);
              }
            }
            catch (DbUpdateConcurrencyException e){
              continue;
            }
            catch (SqliteException e){
              continue;
            }
          }
        }
        catch (InvalidOperationException e){
          continue;
        }
        Thread.Sleep(RandomNumber.Next(200, 600));
      }
    }
  }
}
