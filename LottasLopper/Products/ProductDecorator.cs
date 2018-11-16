using System.Collections.Generic;

namespace LottasLopper{
  public abstract class ProductDecorator : IProduct{
    public string Name{ get; set; }
    public int Price{ get; set; }
    public List<string> DecoratedWith{ get; }
    
    public ProductDecorator(IProduct product){
      Name = product.Name.ToLower();
      Price = product.Price;
      DecoratedWith = product.DecoratedWith;
    }
  }
}
