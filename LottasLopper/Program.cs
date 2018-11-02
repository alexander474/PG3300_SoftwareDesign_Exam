using System;
using LottasLopper.Product;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace LottasLopper{
  class Program{
    private static DbSet<Product.Product> _productProduct;

    static void Main(string[] args){
      ProductContext product = new ProductContext();
      product.Add(new Product.Product("A new name"));
      product.SaveChanges();


      _productProduct = product.Product;
      
      foreach (var product1 in _productProduct){
        Console.WriteLine(product1.Name);
      }
    }
  }
}
