using System;

namespace LottasLopper{
  public class ImprovedProductDecorator : ProductDecorator{
    
    public ImprovedProductDecorator(Product product) : base(product){
      product.Name = String.Format("{0} {1}", new Bogus.Faker().Commerce.ProductAdjective(), product.Name);
    }
  }
}
