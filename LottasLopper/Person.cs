using System;

namespace LottasLopper {
	public abstract class Person {
		protected string Name { get; set; }
		protected int Money { get; set; }
		protected float WaitTime { get; set; }

		public Person(string name, int actions, int money = 0) {
			Name = name;
			Money = money;
			WaitTime = Settings.WaitingScale;
			Action(actions);
		}

		public abstract void Action(int actions);
	}
}
