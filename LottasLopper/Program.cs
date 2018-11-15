using System;
using System.Threading;

namespace LottasLopper {
	class Program {

		static void Main(string[] args) {
			var factory = new PersonFactory();
			factory.CreateSellers(1);
			factory.CreateCustomers(20);
			bool _hasPrinted = false;
			while(true) {
				if(Stats.SellersActive == 0 && Stats.BuyersActive == 0 && !_hasPrinted) {
					_hasPrinted = true;
					Stats.BuyersActive = 0;
					Printer.Print(" ", ConsoleColor.Blue);
					Printer.Print("All buyers and sellers has left, there is nothing left to do.", ConsoleColor.Blue);
					Printer.Print("Press Q to quit..", ConsoleColor.Blue);
					Printer.Print(" ", ConsoleColor.Blue);
				}

				if(Console.KeyAvailable) {
					ConsoleKeyInfo consoleKeyinfo = Console.ReadKey(true);
					if(consoleKeyinfo.Key == ConsoleKey.Q)
						break;
				}
			}
		}
	}
}
