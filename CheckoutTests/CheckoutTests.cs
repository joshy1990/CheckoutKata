using NUnit.Framework;
using static Checkout;

namespace CheckoutKata.Tests
{

    [TestFixture]
    public class CheckoutTests
    {
        [Test]
        public void TestAddingSingleItem()
        {
            // Arrange
            var checkout = new Checkout();
            var itemA = new Item("A", 10);

            // Act
            checkout.Scan(itemA);

            // Assert
            Assert.AreEqual(10, checkout.GetTotalPrice());
        }

        [Test]
        public void TestAddingMultipleItems()
        {
            // Arrange
            var checkout = new Checkout();
            var itemA = new Item("A", 10);
            var itemB = new Item("B", 15);

            // Act
            checkout.Scan(itemA);
            checkout.Scan(itemB);
            checkout.Scan(itemA);

            // Assert
            Assert.AreEqual(35, checkout.GetTotalPrice());
        }

        [Test]
        public void TestApplyingPromotion3For40()
        {
            // Arrange
            var checkout = new Checkout();
            var itemB = new Item("B", 15);

            // Act
            checkout.Scan(itemB);
            checkout.Scan(itemB);
            checkout.Scan(itemB);
            checkout.Scan(itemB);
            checkout.Scan(itemB);
            checkout.Scan(itemB);

            // Assert
            Assert.AreEqual(80, checkout.GetTotalPrice());
        }

        [Test]
        public void TestApplyingPromotion25PercentOff()
        {
            // Arrange
            var checkout = new Checkout();
            var itemD = new Item("D", 55);

            // Act
            checkout.Scan(itemD);
            checkout.Scan(itemD);
            checkout.Scan(itemD);
            checkout.Scan(itemD);
            checkout.Scan(itemD);
            checkout.Scan(itemD);
            checkout.Scan(itemD);
            checkout.Scan(itemD);
            checkout.Scan(itemD);
            

            // Assert
            Assert.AreEqual(220, checkout.GetTotalPrice());
        }


        [Test]
        public void TestApplyingPromotion25PercentOffFail()
        {
            // Arrange
            var checkout = new Checkout();
            var itemD = new Item("D", 55);

            // Act
            checkout.Scan(itemD);
            checkout.Scan(itemD);
            checkout.Scan(itemD);
            checkout.Scan(itemD);

            // Assert
            Assert.AreEqual(220, checkout.GetTotalPrice());
        }

        [Test]
        public void TestAddingDifferentSKUs()
        {
            // Arrange
            var checkout = new Checkout();
            var itemA = new Item("A", 10);
            var itemB = new Item("B", 15);
            var itemD = new Item("D", 55);

            // Act
            checkout.Scan(itemA);
            checkout.Scan(itemA);   
            checkout.Scan(itemB);
            checkout.Scan(itemD);
            checkout.Scan(itemA);
            checkout.Scan(itemB);
            checkout.Scan(itemB);
            checkout.Scan(itemB);
            checkout.Scan(itemA);
          


            // Assert
            Assert.AreEqual(150, checkout.GetTotalPrice());
        }
    }
}
