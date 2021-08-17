using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Model
{
    public class Order
    {
        private Dictionary<Product, int> lineItems;
        private Dictionary<Product, int> promtionAppliedLineItems;
        private double price;

        public Order()
        {
            lineItems = new Dictionary<Product, int>();
            promtionAppliedLineItems = new Dictionary<Product, int>();
        }
        public Dictionary<Product, int> LineItems
        {
            get
            {
                return lineItems;
            }
        }

        public double Price {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }


        public void addPrice(double amount)
        {
            price += amount;
        }

        public Dictionary<Product, int> PromotionAppliedLineItems
        {
            get
            {
                return promtionAppliedLineItems;
            }
        }

        public double LabelPrice
        {
            get
            {
                double price = 0;
                foreach(KeyValuePair<Product, int> item in lineItems)
                {
                    price += item.Key.UnitPrice * item.Value;
                }
                return price;
            }
        }
        public void addLineItem(Product item, int qnty)
        {
            int value;
            if (!lineItems.ContainsKey(item))
            {
                lineItems.Add(item, qnty);
            }
            else
            {
                lineItems.TryGetValue(item, out value);
                value+= qnty;
                lineItems.Remove(item);
                lineItems.Add(item, value);
            }
        }

        public void addPromotionAppliedLineItem(Product item, int qnty)
        {
            int value = 0;
            if (!promtionAppliedLineItems.ContainsKey(item))
            {
                promtionAppliedLineItems.Add(item, qnty);
            }
            else
            {
                promtionAppliedLineItems.TryGetValue(item, out value);
                value += qnty;
                promtionAppliedLineItems.Remove(item);
                promtionAppliedLineItems.Add(item, value);
            }
        }
    }
}
