using NUnit.Framework;

namespace LottasLopper{
    public class ProductTest{

        [Test]
        public void ShouldNotBeNull() {
            var product = new Product(10);
            Assert.IsNotNull(product.Price);
            Assert.IsNotNull(product.Name);
        }

        [Test]
        public void ShouldReturnProductPrice() {
            var product = new Product(10);
            Assert.AreEqual(product.Price,10);
        }
    }
}