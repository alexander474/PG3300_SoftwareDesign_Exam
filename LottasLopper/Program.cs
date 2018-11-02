using System;
using LottasLopper.Product;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace LottasLopper{
  class Program{
    static void Main(string[] args){
      Product.Product product = new Product.Product();
      product.Name = "Test name";
    }
  }
}
