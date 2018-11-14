using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using Faker;

namespace LottasLopper {
	public class Customer : Person {

		public Customer() : base(Faker.Name.FullName(), RandomNumber.Next(1000, 10_000)) {}

		public override void Action(int actions) {
			while(Money > 0 || ProductController.list.Any()) {
				lock(ProductController.list) {
					var _randomProduct = ProductController.getRandomProduct();
					if(_randomProduct == null) continue;
					ProductController.RemoveProduct(_randomProduct);
					if(Money > _randomProduct.Price) {
						Money -= _randomProduct.Price;
						Stats.ItemsSold++;
						Stats.TotalEarnings += _randomProduct.Price;
						Printer.Print(Stats.ItemsSold + "/" + Stats.ItemsListed + " - $" + Stats.TotalEarnings + " - " + Name +
									" bought product: " + _randomProduct.Name + " for $" + _randomProduct.Price,
									ConsoleColor.Yellow);
					}
				}
				Thread.Sleep(RandomNumber.Next(600, 1200));
			}
		}
	}
}
