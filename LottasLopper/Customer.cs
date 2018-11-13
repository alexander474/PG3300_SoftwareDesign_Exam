using System;
using System.Linq;
using System.Threading;
using Faker;

namespace LottasLopper{
  public class Customer : Person{
    private int _attempts = 0;
    
    public Customer() : base(Faker.Name.FullName(), RandomNumber.Next(1000, 10_000)){
    }

    public override void Action(int actions){
      while (Money > 0){
        if (_attempts >= 15){
          Printer.print(Name + " could not find a product or was broke. " + Name + " went home.", ConsoleColor.Red);
          break;
        }
        lock (ProductController.list){
          var randomProduct = ProductController.getRandomProduct();
          // No product available
          if (randomProduct == null){
            _attempts++;
            Printer.print(Name + " is browsing for a new product... ", ConsoleColor.Gray);
            Thread.Sleep(RandomNumber.Next(200, 600));
            continue;
          };
          // attempt to buy product if there is enough money
          if (Money > randomProduct.Price){
            AttemptToBuyProduct(randomProduct);
          }
        }
        Thread.Sleep(RandomNumber.Next(200, 600));
      }
    }

    private void AttemptToBuyProduct(Product randomProduct){
      if (ProductController.removeProduct(randomProduct)){
        Money -= randomProduct.Price;
        Printer.print(Name + " bought product: " +
                      randomProduct.Name + " for $" +
                      randomProduct.Price, ConsoleColor.Yellow);
        _attempts = 0;
      }
    }
  }
}
