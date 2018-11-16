namespace LottasLopper{
  public abstract class ProductDecorator : IProduct{
    public string Name{ get; set; }
    public int Price{ get; set; }
    
    public ProductDecorator(Product product){
      Name = product.Name;
      Price = product.Price;
    }
  }
}
