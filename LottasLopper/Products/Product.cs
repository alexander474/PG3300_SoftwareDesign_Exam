using System;
using System.Collections.Generic;

namespace LottasLopper {
	public class Product : IProduct {
		public string Name { get; set; }
		public int Price { get; set; }
		public List<string> DecoratedWith{ get; }

		public Product(int price) {
			DecoratedWith = new List<string>();
			Name = new Bogus.Faker().Commerce.Product();
			Price = price;
		}

		public string GetProductName(){
			return Name;
		}

		public int GetPrice(){
			return Price;
		}
	}
}
