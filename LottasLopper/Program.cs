using System;
using Faker;
using LottasLopper.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace LottasLopper{
  class Program{

    static void Main(string[] args){
      PersonFactory factory = new PersonFactory();
      factory.CreateSellers(10);
      factory.CreateCustomers(50);
    }
  }
}
