using System;
using System.Threading;
using Faker;

namespace LottasLopper {
	public class Seller : Person {
		public Seller() : base(Faker.Name.FullName(), 0) {}

		public override void Action(int actions) {
			for(int i = 0; i < actions; i++) {
				Thread.Sleep(RandomNumber.Next(800, 3000));
				var newProduct = new Product();
				new ProductController().AddToList(newProduct);
				Stats.ItemsListed++;
				Printer.Print("Seller " + Name + ", added product: " + newProduct.Name + " for $" + newProduct.Price, ConsoleColor.Red);
			}
		}
	}
}
