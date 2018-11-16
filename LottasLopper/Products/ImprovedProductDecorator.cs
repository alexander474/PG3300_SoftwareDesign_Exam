using System;

namespace LottasLopper{
  public class ImprovedProductDecorator : ProductDecorator{
    
    public ImprovedProductDecorator(IProduct product) : base(product){
      string _name = new Bogus.Faker().Commerce.ProductAdjective();
      Name = String.Format("{0} {1}", char.ToUpper(_name[0]) + _name.Substring(1), Name);
      DecoratedWith.Add("Improved");
    }
  }
}
