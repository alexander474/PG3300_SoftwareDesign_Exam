using System;
using System.Threading;

namespace LottasLopper{
  public class Seller : Person{
    public Seller() : base(new Bogus.Faker().Name.FullName(), 0){
    }

    public override void Action(int actions){
      for (int i = 0; i < actions; i++){
        var newProduct = new Product();
        new ProductController().addToList(newProduct);
        Printer.print(String.Format("Seller {0} added product: {1} for ${2}", Name, newProduct.Name, newProduct.Price), ConsoleColor.Red);
        Thread.Sleep(new Random().Next(1000, 2000));
      }
    }
  }
}
