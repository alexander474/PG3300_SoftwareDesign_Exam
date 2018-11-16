using System;

namespace LottasLopper{
  public class MaterialProductDecorator: ProductDecorator{
    
    public MaterialProductDecorator(Product product) : base(product){
      product.Name = String.Format("{0} {1}", new Bogus.Faker().Commerce.ProductMaterial(), product.Name);
    }
  }
}
