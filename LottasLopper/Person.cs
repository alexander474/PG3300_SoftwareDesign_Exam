using System;
using Faker;

namespace LottasLopper {
	public abstract class Person {
		public string Name { get; set; }
		public int Money { get; set; }

		public Person(string name, int money) {
			Name = name;
			Money = money;
			Action(10);
		}

		public abstract void Action(int actions);
	}
}
