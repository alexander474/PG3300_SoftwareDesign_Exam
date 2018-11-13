using System;
using Faker;

namespace LottasLopper{
  class Program{

    static void Main(string[] args){
      PersonFactory factory = new PersonFactory();
      factory.CreateSellers(10);
      factory.CreateCustomers(50);
    }
  }
}
