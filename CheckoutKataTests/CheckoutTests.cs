using System;
using System.Linq;
using CheckoutKata;
using Moq;
using NUnit.Framework;

namespace CheckoutKataTests
{
    [TestFixture]
    public class CheckoutTests
    {
        [TestCase("A", 1)]
        [TestCase("AA", 2)]
        [TestCase("ABC", 3)]
        [TestCase("AAB", 3)]
        [Test]
        public void Should_TrackNumberOfItemsScanned(string basket, int expectedCount)
        {
            // Arrange
            var priceSystemMock = new Mock<PriceSystem>();
            var checkout = new Checkout(priceSystemMock.Object);

            // Act
            checkout.Scan(basket);

            // Assert
            var totalItems = checkout.Items.Sum(x => x.Value);

            Assert.AreEqual(expectedCount, totalItems);
        }

        [TestCase("A", 50)]
        [TestCase("AA", 100)]
        [TestCase("B", 30)]
        [TestCase("AB", 80)]
        [TestCase("ABA", 130)]
        [TestCase("ABC", 95)]
        [TestCase("AAA", 130)]
        [Test]
        public void Should_CalculateCorrectPriceForBasket(string basket, int totalPrice)
        {
            // Arrange
            var priceSystem = new PriceSystem();
            var checkout = new Checkout(priceSystem);

            foreach (var i in basket)
            {
                checkout.Scan(i);
            }

            // Act
            var basketPrice = checkout.CalculatePrice();

            // Assert
            Assert.AreEqual(totalPrice, basketPrice);
        }

        [Test]
        public void Should_ItemiseBasket()
        {
            // Arrange
            var priceSystem = new PriceSystem();
            var checkout = new Checkout(null);
            var basket = "AAABBC";

            // Act
            checkout.Scan(basket);

            // Assert
            Assert.AreEqual(3, checkout.Items['A']);
            Assert.AreEqual(2, checkout.Items['B']);
            Assert.AreEqual(1, checkout.Items['C']);
        }
    }
}