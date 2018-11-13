using System;

namespace LottasLopper{
  class Program{

    static void Main(string[] args){
      PersonFactory factory = new PersonFactory();
      factory.CreateSellers(1);
      factory.CreateCustomers(3);
    }
  }
}
