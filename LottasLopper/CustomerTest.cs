namespace LottasLopper{
    using NUnit.Framework;
    public class CustomerTest{

        [Test]
        public void shouldNotBeNull(){
            var customer = new Customer();
            Assert.IsNotNull(customer.Money);
            Assert.IsNotNull(customer.Name);
            Assert.IsNotNull(customer.WaitTime);
            Assert.Greater(customer.Money,0);
        }

        [Test]
        public void shouldFail() {
            var customer = new Customer();
            Assert.Equals(customer.Money, 0);
        }

    }
}