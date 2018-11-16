
using System;

namespace LottasLopper {
	class Settings {
		
		#region Actions
		public static int SellerActions {
			get { return 5; }
		}
		public static int CustomerActions {
			get { return 10; }
		}
		#endregion
		#region Price
		public static int MaxPrice {
			get { return 1500; }
		}
		public static int MinPrice {
			get { return 200; }
		}
		#endregion
		#region Customer Money
		public static int MaxMoney {
			get {
				return 5000;
			}
		}
		public static int MinMoney {
			get { return 1000; }
		}
		#endregion
		#region Customers/Seller
		public static int CustomerCount {
			get { return 50; }
		}
		public static int SellerCount {
			get { return 200; }
		}
		#endregion


		public static float WaitingScale {
			get { return (float) (new Random().Next(75, 150) / 100); }
		}

	}
}
