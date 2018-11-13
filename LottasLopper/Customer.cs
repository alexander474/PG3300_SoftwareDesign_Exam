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
        lock (ProductController.list){
          ProductController.removeProduct(randomProduct);
          if (Money > randomProduct.Price){
            Money -= randomProduct.Price;
            Printer.print(Name + " bought product: " +
                          randomProduct.Name + " for $" +
                          randomProduct.Price, ConsoleColor.Yellow);
          }
        }
        Thread.Sleep(RandomNumber.Next(200, 600));
      }
    }
  }
}
