using System;

namespace LottasLopper {
	public abstract class Person {
		public string Name { get; protected set; }
		public int Money { get; protected set; }

		public Person(string name, int actions, int money = 0) {
			Name = name;
			Money = money;
			Action(actions);
		}

		public abstract void Action(int actions);
	}
}
