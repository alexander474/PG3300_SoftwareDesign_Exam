using System;
using System.Collections.Generic;
using System.Linq;
using Faker;

namespace LottasLopper{
  public class ProductController{
    public static readonly object _product = new Object();
    public static List<Product> list = new List<Product>();
    
    public static Product getRandomProduct(){
      try{
        if (list.Any()){
          return list[RandomNumber.Next(0, list.Count)];
        }
      }
      catch (InvalidOperationException){
        return null;
      }
      return null;
    }

    public void addToList(Product product){
      list.Add(product);
    }

    public static void removeProduct(Product product){
      lock (_product){
        list.Remove(product);
      }
    }
  }
}
