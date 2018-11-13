using System;
using System.Threading;
using Faker;

namespace LottasLopper{
  public class Seller : Person{
    public Seller() : base(Faker.Name.FullName(), 0){
    }

    public override void Action(int actions){
      for (int i = 0; i < actions; i++){
        var newProduct = new Product();
        new ProductController().addToList(newProduct);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Seller " + Name + ", added product: " + newProduct.Name + " for $" + newProduct.Price);
        Thread.Sleep(RandomNumber.Next(1000, 2000));
      }
    }
  }
}
