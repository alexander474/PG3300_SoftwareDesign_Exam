using Faker;

namespace LottasLopper{
  public class Product{
    public string Name{ get; set; }
    public int Price{ get; set; }
    
    public Product(string name, int price){
      Name = name;
      Price = price;
    }

    public Product(){
      Name = new Bogus.Faker().Commerce.ProductName();
      Price = RandomNumber.Next(200, 1000);
    }
  }
}
