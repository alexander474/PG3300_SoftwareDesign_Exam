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

		public IProduct GenerateRandomDecorated(IProduct product){
			int i = 0;
			int numberOfDecorations = new Random().Next(0, 4);
			IProduct _product = product;
			while (i++ < numberOfDecorations){
				_product = DecorateProduct(_product);
			}

			return _product;
		}

		private IProduct DecorateProduct(IProduct product){
			switch (new Random().Next(0, 4)){
				case 0:
					if (IsDecoratedWith(product, "Improved")) return product;
					return new ImprovedProductDecorator(product);
				case 1:
					if (IsDecoratedWith(product, "Colored")) return product;
					return new ColoredProductDecorator(product);
				case 2:
					if (IsDecoratedWith(product, "Material")) return product;
					return new MaterialProductDecorator(product);
				default:
					return product;
			}
		}

		private bool IsDecoratedWith(IProduct product, string decorator){
			return product.DecoratedWith.Contains(decorator);
		}
	}
}
