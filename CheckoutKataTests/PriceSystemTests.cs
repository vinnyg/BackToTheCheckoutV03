using CheckoutKata;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKataTests
{
    [TestFixture]
    public class PriceSystemTests
    {
        [Test]
        [TestCase('A', 50)]
        [TestCase('B', 30)]
        [TestCase('C', 15)]
        public void Should_ReturnCorrectPriceForProduct(char item, int expectedPrice)
        {
            // Arrange
            var priceSystem = new PriceSystem();

            // Act
            int itemPrice = priceSystem.GetPrice(item);

            // Assert
            Assert.AreEqual(expectedPrice, itemPrice);
        }

        [Test]
        [TestCase("AAA", 20)]
        [TestCase("BB", 15)]
        [TestCase("AAAAAA", 40)]
        [TestCase("AAABB", 35)]
        public void Should_ReturnCorrectDiscount(string basket, int expectedDiscount)
        {
            // Arrange
            var priceSystem = new PriceSystem();
            var checkout = new Checkout(priceSystem);

            checkout.Scan(basket);

            // Act
            var discount = priceSystem.CalculateDiscounts(checkout.Items);

            // Assert
            Assert.AreEqual(expectedDiscount, discount);
        }
    }
}