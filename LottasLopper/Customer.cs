using System;
using System.Linq;
using System.Threading;
using Faker;

namespace LottasLopper{
  public class Customer : Person{

    public Customer() : base(Faker.Name.FullName(), RandomNumber.Next(1000, 3000)){
    }
    
    public override void Action(int actions){
      while (Money > 0 || ProductController.list.Any()){
        var randomProduct = ProductController.getRandomProduct();
        if(randomProduct == null) continue;
        lock (randomProduct){
          ProductController.list.Remove(randomProduct);
          if (Money > randomProduct.Price){
            Money -= randomProduct.Price;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Name + " bought product: " +
                              randomProduct.Name + " for $" +
                              randomProduct.Price);
          }
        }
        Thread.Sleep(RandomNumber.Next(200, 600));
      }
    }
  }
}
