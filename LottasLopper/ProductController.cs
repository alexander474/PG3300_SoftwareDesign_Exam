using System;
using System.Collections.Generic;
using System.Linq;

namespace LottasLopper {
	public class ProductController {
		private static readonly object _product = new Object();
		public static List<Product> list = new List<Product>();

		public static Product GetRandomProduct() {
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

		public void AddToList(Product product) {
			list.Add(product);
		}

		public static bool RemoveProduct(Product product) {
			return list.Remove(product);
		}
	}
}
