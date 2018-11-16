using System;

namespace LottasLopper{
  public class ColoredProductDecorator : ProductDecorator{
    
    public ColoredProductDecorator(IProduct product) : base(product){
      string _name = new Bogus.Faker().Commerce.Color();
      Name = String.Format("{0} {1}",  char.ToUpper(_name[0]) + _name.Substring(1), Name);
      DecoratedWith.Add("Color");
    }
  }
}
