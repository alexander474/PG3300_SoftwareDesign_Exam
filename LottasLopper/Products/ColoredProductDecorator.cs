using System;

namespace LottasLopper{
  public class ColoredProductDecorator : ProductDecorator{
    
    public ColoredProductDecorator(Product product) : base(product){
      product.Name = String.Format("{0} {1}", new Bogus.Faker().Commerce.Color(), product.Name);
    }
  }
}
