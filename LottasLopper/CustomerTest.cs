using NUnit.Framework;

namespace LottasLopper{
    public class CustomerTest{

        [Test]
        public void ShouldNotBeNull(){
            var customer = new Customer();
            Assert.IsNotNull(customer.Money);
            Assert.IsNotNull(customer.Name);
            Assert.Greater(customer.Money,0);
        }

        [Test]
        public void ShouldFail() {
            var customer = new Customer();
            Assert.Equals(customer.Money, 0);
        }

    }
}