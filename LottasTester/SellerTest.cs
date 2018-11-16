using NUnit.Framework;

namespace LottasLopper{
    public class SellerTest{

        [Test]
        public void ShouldNotBeNull() {
            var seller = new Seller();
            Assert.IsNotNull(seller.Money);
            Assert.IsNotNull(seller.Name);
        }

        [Test]
        public void ShouldHaveMoneyEqualsZero() {
            var seller = new Seller();
            Assert.AreEqual(seller.Money, 0);
        }
    }
}