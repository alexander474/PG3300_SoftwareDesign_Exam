using System;
using System.Collections.Generic;
using System.Linq;

namespace LottasLopper {
	public class ProductController {
		private static readonly object _product = new Object();
		public static List<IProduct> list = new List<IProduct>();

		public static IProduct GetRandomProduct() {
			lock(_product) {
				try {
					if(list.Any()) {
						return list[new Random().Next(0, list.Count)];
					}
				} catch(InvalidOperationException) {
					return null;
				}
				return null;
			}
		}

		public void AddToList(IProduct product) {
			list.Add(product);
		}

		public static bool RemoveProduct(IProduct product) {
			return list.Remove(product);
		}

		public IProduct generateRandomDecorated(Product product){
			switch (new Random().Next(0, 4)){
					case 0:
						return new ImprovedProductDecorator(product);
					case 1:
						return new ColoredProductDecorator(product);
					case 2:
						return new MaterialProductDecorator(product);
					default:
						return product;
			}
		}
	}
}
