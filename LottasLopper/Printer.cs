using System;
using System.IO;
using System.Threading;

namespace LottasLopper {
	public class Printer {
		private static readonly object _console = new Object();
		private static int _lastPos = 0;

		public static void Print(string text, ConsoleColor color) {
			lock(_console) {
			    try {
				    Thread.Sleep(20); //Delay printing to remove flickering in console
			        Console.SetCursorPosition(0, _lastPos);
			        Console.Write(new string(' ', Console.WindowWidth)); //Clear a single line in console
			        Console.SetCursorPosition(0, _lastPos);
			        Console.ForegroundColor = color;
			        Console.WriteLine(text);
			        _lastPos = Console.CursorTop;
			        PrintStats();
                }catch (IOException) {
			        // Ignore this error. It means the console is not present
			        // F.eks in tests it fails on one of our environments
			    }
                
			}
		}

		private static void PrintStats() {
	        if (_lastPos >= Console.WindowHeight) {
	            Console.SetCursorPosition(0, _lastPos);
	        }
	        else {
	            Console.SetCursorPosition(0, Console.WindowHeight - 1);
	        }

	        Console.ForegroundColor = ConsoleColor.Green;
	        Console.Write(String.Format("{0} / {1} items sold - ${2} earend so far - {3} sellers active - {4} buyers active",
	            Stats.ItemsSold,
	            Stats.ItemsListed,
	            Stats.TotalEarnings,
	            Stats.SellersActive,
	            Stats.CustomersActive
	        ));

        }
	}
}