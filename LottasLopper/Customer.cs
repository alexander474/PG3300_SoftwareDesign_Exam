using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace LottasLopper {
	public class Customer : Person {
		private static readonly object _lock = new Object();
		private int _sleepTime;
		private int _attempts = 0;

        // Creates a customer with a random name and a wallet with currency between 1000 and 10_000.
		public Customer() : base(new Bogus.Faker().Name.FullName(), Settings.CustomerActions,
								new Random().Next(Settings.MinMoney, Settings.MaxMoney)) {}

		public override void Action(int actions) {
			bool running = true;
			while(running) {
				_sleepTime = new Random().Next(100, 400);
				lock(_lock) {
					if(_attempts >= actions || Money < Settings.MinPrice) {
						Printer.Print(String.Format("{0} couldn't find a product or was broke. {0} went home. Had ${1} left", Name, Money), ConsoleColor.DarkCyan);
						Stats.CustomersActive--;
						running = false;
						continue;
					}
					var randomProduct = ProductController.GetRandomProduct();
					// No product available
					if(randomProduct == null) {
						// Add 1 to attempts and sleep for a bit before trying again
						_attempts++;
						Printer.Print(String.Format("{0} is browsing for a new product... ", Name), ConsoleColor.Gray);
						_sleepTime = new Random().Next(800, 1200);
					} else if(Money < randomProduct.Price) {
						// Add 1 to attempts and sleep for a bit before trying again
						_attempts++;
						Printer.Print(String.Format("{0} tried to buy product {1}, but was missing ${2}",
							Name,
							randomProduct.Name,
							randomProduct.Price - Money),
							ConsoleColor.Gray);
					} else {
						// Attempt to buy product
						AttemptToBuyProduct(randomProduct);
					}
				}
				Thread.Sleep(_sleepTime);
			}
			
		}

		private void AttemptToBuyProduct(IProduct randomProduct) {
			if(ProductController.RemoveProduct(randomProduct)) {
				// Did manage to buy product,
				// set attempts to 0 because the customer is satisfied and wants to shop more
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
