using System;

namespace LottasLopper {
	public class Product {
		public string Name { get; set; }
		public int Price { get; set; }

		public Product() {
			Name = new Bogus.Faker().Commerce.ProductName();
			Price = new Random().Next(200, 1000);
		}
	}
}
