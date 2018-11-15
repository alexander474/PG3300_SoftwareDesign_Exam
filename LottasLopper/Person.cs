using System;

namespace LottasLopper {
	public abstract class Person {
		public string Name { get; private set; }
		public int Money { get; private set; }
		public float WaitTime { get; private set; }

		public Person(string name, int actions, int money = 0) {
			Name = name;
			Money = money;
			WaitTime = Settings.WaitingScale;
			Action(actions);
		}

		public abstract void Action(int actions);
	}
}
