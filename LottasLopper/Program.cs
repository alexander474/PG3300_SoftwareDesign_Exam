using System;
using Faker;

namespace LottasLopper {
	class Program {
		static void Main(string[] args) {
			PersonFactory _factory = new PersonFactory();
			_factory.CreateSellers(3);
			_factory.CreateCustomers(5);
		}
	}
}
