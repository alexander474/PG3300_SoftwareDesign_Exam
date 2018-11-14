using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace LottasLopper {
	public class Customer : Person {
		private int _attempts = 0;

        // Creates a customer with a random name and a wallet with currency between 1000 and 10_000.
		public Customer() : base(new Bogus.Faker().Name.FullName(), new Random().Next(1000, 10_000)) {
		}

		public override void Action(int actions) {
			while(Money > 0) {
				if(_attempts >= 10) {
					Printer.Print(String.Format("{0} could not find a product or was broke. {0} went home.", Name), ConsoleColor.Red);
					break;
				}
				lock(ProductController.list) {
					var randomProduct = ProductController.GetRandomProduct();
					// No product available
					if(randomProduct == null) {
						_attempts++;
						Printer.Print(String.Format("{0} is browsing for a new product... ", Name), ConsoleColor.Gray);
						Thread.Sleep(new Random().Next(500, 1000));
						continue;
					};
					// attempt to buy product if there is enough money
					if(Money > randomProduct.Price) {
						AttemptToBuyProduct(randomProduct);
					}
				}
				Thread.Sleep(new Random().Next(200, 600));
			}
		}

		private void AttemptToBuyProduct(Product randomProduct) {
			if(ProductController.RemoveProduct(randomProduct)) {
				Money -= randomProduct.Price;
				Stats.ItemsSold++;
				Stats.TotalEarnings += randomProduct.Price;
				Printer.Print(String.Format("{0} bought product: {1} for ${2}",
					Name, randomProduct.Name, randomProduct.Price), ConsoleColor.Yellow);
				_attempts = 0;
			}
		}
	}
}
