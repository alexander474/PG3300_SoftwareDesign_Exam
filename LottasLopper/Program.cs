using System;

namespace LottasLopper {
	class Program {

		static void Main(string[] args) {
			var factory = new PersonFactory();
			factory.CreateSellers(20);
			factory.CreateCustomers(30);
			while(true) {
				if(Stats.SellersActive == 0 && Stats.BuyersActive <= 1) {
					Printer.Print(" ", ConsoleColor.Blue);
					Printer.Print("Press UP_ARROW to exit..", ConsoleColor.Blue);
					Printer.Print(" ", ConsoleColor.Blue);
				}

				if(Console.ReadKey().Key == ConsoleKey.UpArrow) {
					break;
				}
			}
		}
	}
}
