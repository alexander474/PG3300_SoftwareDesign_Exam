using System;

namespace LottasLopper {
	class Program {

		static void Main(string[] args) {
			var factory = new PersonFactory();
			factory.CreateSellers(1);
			factory.CreateCustomers(3);
		}
	}
}
