using System;

namespace LottasLopper {
	public class Printer {
		private static readonly object _console = new Object();
		private static int _lastPos = 0;

		public static void Print(string text, ConsoleColor color) {
			lock(_console) {
				Console.SetCursorPosition(0, _lastPos);
				Console.ForegroundColor = color;
				Console.WriteLine(text);
				_lastPos = Console.CursorTop;
				PrintStats();
			}
		}

		private static void PrintStats() {
			if(_lastPos >= Console.WindowHeight) {
				Console.SetCursorPosition(0, _lastPos);
			} else {
				Console.SetCursorPosition(0, Console.WindowHeight);
			}

			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write(String.Format("{0} / {1} items sold, ${2} earnd so far.", Stats.ItemsSold, Stats.ItemsListed, Stats.TotalEarnings));
		}
	}
}