using System.Threading;

namespace LottasLopper {
	public class PersonFactory {

		public void CreateSellers(int numberOfSellers) {
			for(int i = 0; i < numberOfSellers; i++) {
				new Thread(NewSeller).Start();
			}
		}

		public void CreateCustomers(int numberOfCustomers) {
			for(int i = 0; i < numberOfCustomers; i++) {
				new Thread(NewCustomer).Start();
			}
		}

		void NewSeller() {
			new Seller();
		}

		void NewCustomer() {
			new Customer();
		}
	}
}
