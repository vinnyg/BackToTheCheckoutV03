using System;
using System.Collections.Generic;
using System.Text;

namespace CheckoutKata
{
    public class DiscountRule
    {
        public int MinimumQuantity { get; private set; }
        public int DiscountAmount { get; private set; }

        public DiscountRule(int quantity, int discountAmount)
        {
            MinimumQuantity = quantity;
            DiscountAmount = discountAmount;
        }
    }
}
