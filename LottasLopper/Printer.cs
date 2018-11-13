using System;

namespace LottasLopper{
  public class Printer{
    private static readonly object _console = new Object();
    
    public static void print(string text, ConsoleColor color){
      lock (_console){
        Console.ForegroundColor = color;
        Console.WriteLine(text);
      }
    }
  }
}
