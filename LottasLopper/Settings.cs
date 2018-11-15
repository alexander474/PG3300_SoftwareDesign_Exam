
using System;

namespace LottasLopper {
	class Settings {
		
		public static int SellerActions {
			get { return 2; }
		}
		public static int BuyerActions {
			get { return 2; }
		}
		public static float WaitingScale {
			get { return (float) (new Random().Next(75, 150) / 100); }
		}

	}
}
