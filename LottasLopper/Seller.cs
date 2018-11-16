using System;
using System.Threading;

namespace LottasLopper {
	public class Seller : Person {
		private static readonly object _listLock = new Object();
	    // Creates a seller with a random name and a wallet with currency of 0.
		public Seller() : base(new Bogus.Faker().Name.FullName(), Settings.SellerActions) {}

		public override void Action(int actions) {
			Thread.Sleep(new Random().Next(500, 5000));
			for(int i = 0; i <= actions; i++) {
				lock(_listLock) {
					if(i == actions) {
						Stats.SellersActive--;
						Printer.Print(String.Format("Seller {0} has no more items to sell, and is going home", Name), ConsoleColor.Cyan);
						break;
					}
					var newProduct = new ProductController().generateRandomDecorated(new Product(new Random().Next(Settings.MinPrice, Settings.MaxPrice)));
					new ProductController().AddToList(newProduct);
					Stats.ItemsListed++;
					Printer.Print(String.Format("Seller {0} added product: {1} for ${2}", Name, newProduct.Name, newProduct.Price), ConsoleColor.Red);
				}
				Thread.Sleep(2000);
				//Thread.Sleep((int)Math.Floor(new Random().Next(800, 2000) * WaitTime));
			}
		}
	}
}
