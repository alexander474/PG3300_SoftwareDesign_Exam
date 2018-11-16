using System;
using System.Threading;

namespace LottasLopper {
	class Program {

		private static PersonFactory _factory = new PersonFactory();

		static void Main(string[] args) {

			new Thread(StartCreatingSellers).Start();
			Thread.Sleep(1000);
			new Thread(StartCreatingCustomers).Start();
			
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

		private static void StartCreatingSellers() {
			_factory.CreateSellers(200);
		}

		private static void StartCreatingCustomers() {
			_factory.CreateCustomers(50);
		}
	}
}
