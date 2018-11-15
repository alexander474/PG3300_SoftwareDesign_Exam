using System;

namespace LottasLopper {
	public class Product {
		public string Name { get; set; }
		public int Price { get; set; }

		public Product(int price) {
			Name = new Bogus.Faker().Commerce.ProductName();
			Price = price;
		}
	}
}
