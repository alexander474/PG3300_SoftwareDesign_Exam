using System;

namespace LottasLopper {
	public class Product : IProduct {
		public string Name { get; set; }
		public int Price { get; set; }

		public Product(int price) {
			Name = new Bogus.Faker().Commerce.Product();
			Price = price;
		}

		public string getProductName(){
			return Name;
		}

		public int getPrice(){
			return Price;
		}
	}
}
