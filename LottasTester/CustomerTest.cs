using NUnit.Framework;

namespace LottasLopper{
    public class CustomerTest{

        [Test]
        public void ShouldNotBeNull(){
            var customer = new Customer();
            Assert.IsNotNull(customer.Money);
            Assert.IsNotNull(customer.Name);
        }

        [Test]
        public void ShouldHaveMoreMoneyThanZero() {
            var customer = new Customer();
            Assert.Greater(customer.Money, 0);
        }



    }
}