using System;
using System.Threading;

namespace LottasLopper {
	class Program {

		private static PersonFactory _factory = new PersonFactory();

		static void Main(string[] args) {

			Console.CursorVisible = false;
			new Thread(StartCreatingSellers).Start();
			Thread.Sleep(1000);
			new Thread(StartCreatingCustomers).Start();
			
			bool _hasPrinted = false;
			while(true) {
				if(Stats.SellersActive == 0 && Stats.CustomersActive == 0 && !_hasPrinted) {
					_hasPrinted = true;
					Stats.CustomersActive = 0;
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
			_factory.CreateSellers(Settings.SellerCount);
		}

		private static void StartCreatingCustomers() {
			_factory.CreateCustomers(Settings.CustomerCount);
		}
	}
}
