using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CheckoutKata
{
    public class PriceSystem
    {
        private Dictionary<char, int> itemPrices;
        private Dictionary<char, DiscountRule> itemDiscountRules;

        public PriceSystem()
        {
            itemPrices = new Dictionary<char, int>();

            itemPrices.Add('A', 50);
            itemPrices.Add('B', 30);
            itemPrices.Add('C', 15);

            itemDiscountRules = new Dictionary<char, DiscountRule>();

            itemDiscountRules.Add('A', new DiscountRule(3, 20));
            itemDiscountRules.Add('B', new DiscountRule(2, 15));
        }

        public int GetPrice(char item)
        {
            return itemPrices[item];
        }

        public int CalculateDiscounts(Dictionary<char, int> itemisedBasket)
        {
            var totalDiscount = 0;

            itemisedBasket = itemisedBasket.Where
                (x => itemDiscountRules.ContainsKey(x.Key))
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var i in itemisedBasket)
            {
                if (i.Value >= itemDiscountRules[i.Key].MinimumQuantity)
                {
                    var applicationCount = i.Value / itemDiscountRules[i.Key].MinimumQuantity;
                    totalDiscount += itemDiscountRules[i.Key].DiscountAmount * applicationCount;
                }
            }

            return totalDiscount;
        }
    }
}