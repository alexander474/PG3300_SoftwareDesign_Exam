using System;
using System.Threading;

namespace LottasLopper {
	public class Seller : Person {
		private static readonly object _listLock = new Object();
	    // Creates a seller with a random name and a wallet with currency of 0.
		public Seller() : base(new Bogus.Faker().Name.FullName(), 0) {}

		public override void Action(int actions) {
			for(int i = 0; i <= actions; i++) {
				lock(_listLock) {
					if(i == actions) {
						Printer.Print(String.Format("Seller {0} has no more items to sell, and is going home", Name), ConsoleColor.Cyan);
						Stats.SellersActive--;
						break;
					}
					var newProduct = new Product();
					new ProductController().AddToList(newProduct);
					Stats.ItemsListed++;
					Printer.Print(String.Format("Seller {0} added product: {1} for ${2}", Name, newProduct.Name, newProduct.Price), ConsoleColor.Red);
				}
				Thread.Sleep(new Random().Next(200, 2000));
			}
		}
	}
}
