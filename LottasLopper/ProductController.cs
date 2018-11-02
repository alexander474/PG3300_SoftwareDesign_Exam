using System;
using System.Collections;
using System.Linq;
using System.Security.Cryptography;
using Faker;
using LottasLopper.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace LottasLopper{
  public class ProductController{
    
    // Find product by id
    public Product getProduct(int id){
      return new ModelContext().Find<Models.Product>(id);
    }
    
    
    // Get Random product
    public Product getRandomProduct(){
      DbSet<Product> allProducts = new ModelContext().Product;
      if (allProducts.Any()){
        return allProducts.OrderBy(o => Guid.NewGuid()).FirstOrDefault();
      }
      return null;
    }
  }
}
