using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Model;

namespace ShoppingCart.Engine
{
    public class PricingEngine 
    {
        private List<Promotion> promotions;
        

        public PricingEngine()
        {
            promotions = new List<Promotion>();

        }
        public List<Promotion> Promotions
        {
            get
            {
                return promotions;
            }
        }
        public Order Cart { get; set; }
        public void addPromotion(Promotion promotion)
        {
            promotions.Add(promotion);
        }
        public void addPromotion(List<Promotion> promotions)
        {
            promotions.AddRange(promotions);
        }

        public void applyPromotion()
        {
            foreach(Promotion item in promotions)
            {
                bool validPromotion = true;
                
                foreach (KeyValuePair<Product, int> proItems in item.PromotionItems)
                {
                    int value = 0;
                    Cart.LineItems.TryGetValue(proItems.Key, out value);
                    if(value < proItems.Value)
                    {
                        validPromotion = false;
                        break;
                    }
                }
                if(validPromotion == true)
                {
                    int tmpCnt = 0;
                    foreach (KeyValuePair<Product, int> proItems in item.PromotionItems)
                    {
                        tmpCnt = 0;
                        Cart.LineItems.TryGetValue(proItems.Key, out tmpCnt);
                        tmpCnt = tmpCnt / proItems.Value;
                        Cart.addPromotionAppliedLineItem(proItems.Key, proItems.Value * tmpCnt);
                    }
                    Cart.addPrice(item.Price * tmpCnt);
                }
                
            }

        }
        public void CalculatePrice()
        {
            foreach(KeyValuePair <Product, int> item in Cart.LineItems)
            {
                int value = 0;
                Cart.PromotionAppliedLineItems.TryGetValue(item.Key, out value);
                Cart.addPrice((item.Value - value) * item.Key.UnitPrice);
            }
        }
    }
}
