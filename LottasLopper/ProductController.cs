using System;
using System.Collections.Generic;
using System.Linq;
using Faker;

namespace LottasLopper {
	public class ProductController {
		private static readonly object _product = new Object();
		public static List<Product> list = new List<Product>();

		public static Product getRandomProduct() {
			lock(_product) {
				try {
					if(list.Any()) {
						return list[RandomNumber.Next(0, list.Count)];
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

		public static void RemoveProduct(Product product) {
			lock(_product) {
				list.Remove(product);
			}
		}
	}
}
