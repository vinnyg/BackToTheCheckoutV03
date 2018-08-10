using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKata
{
    public class Checkout
    {
        public Dictionary<char, int> Items { get; private set; }
        private PriceSystem priceSystem { get; set; }

        public Checkout(PriceSystem priceSystem)
        {
            Items = new Dictionary<char, int>();
            this.priceSystem = priceSystem;
        }

        public void Scan(string item)
        {
            foreach (var i in item)
            {
                Scan(i);
            }
        }

        public void Scan(char item)
        {
            if (Items.ContainsKey(item))
            {
                ++Items[item];
            }
            else
            {
                Items.Add(item, 1);
            }
        }

        public int CalculatePrice()
        {
            int totalPrice = 0;

            foreach (var i in Items)
            {
                totalPrice += (priceSystem.GetPrice(i.Key) * i.Value);
            }

            var discountTotal = priceSystem.CalculateDiscounts(Items);

            totalPrice -= discountTotal;

            return totalPrice;
        }
    }
}