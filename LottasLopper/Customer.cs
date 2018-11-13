using System;
using System.Linq;
using System.Threading;

namespace LottasLopper{
  public class Customer : Person{
    private int _attempts = 0;
    
    public Customer() : base(new Bogus.Faker().Name.FullName(), new Random().Next(1000, 10_000)){
    }

    public override void Action(int actions){
      while (Money > 0){
        if (_attempts >= 15){
          Printer.print(String.Format("{0} could not find a product or was broke. {0} went home.", Name), ConsoleColor.Red);
          break;
        }
        lock (ProductController.list){
          var randomProduct = ProductController.getRandomProduct();
          // No product available
          if (randomProduct == null){
            _attempts++;
            Printer.print(String.Format("{0} is browsing for a new product... ", Name), ConsoleColor.Gray);
            Thread.Sleep(new Random().Next(200, 600));
            continue;
          };
          // attempt to buy product if there is enough money
          if (Money > randomProduct.Price){
            AttemptToBuyProduct(randomProduct);
          }
        }
        Thread.Sleep(new Random().Next(200, 600));
      }
    }

    private void AttemptToBuyProduct(Product randomProduct){
      if (ProductController.removeProduct(randomProduct)){
        Money -= randomProduct.Price;
        Printer.print(String.Format("{0} bought product: {1} for ${2}",
            Name, randomProduct.Name, randomProduct.Price), ConsoleColor.Yellow);
        _attempts = 0;
      }
    }
  }
}
