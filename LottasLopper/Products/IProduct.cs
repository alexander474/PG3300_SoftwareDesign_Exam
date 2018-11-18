using System;
using System.Collections.Generic;

namespace LottasLopper {
	public interface IProduct {
		string Name { get; set; }
		int Price { get; set; }
		List<string> DecoratedWith { get; }
	}
}
