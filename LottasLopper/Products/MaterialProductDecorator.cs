using System;

namespace LottasLopper{
  public class MaterialProductDecorator: ProductDecorator{
    
    public MaterialProductDecorator(IProduct product) : base(product){
      string _name = new Bogus.Faker().Commerce.ProductMaterial();
      Name = String.Format("{0} {1}", char.ToUpper(_name[0]) + _name.Substring(1), Name);
      DecoratedWith.Add("Material");
    }
  }
}
