using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Model
{
    public class Promotion
    {
        private Dictionary<Product, int> promotionItems;
        public Dictionary<Product, int> PromotionItems
        {
            get
            {
                return promotionItems;
            }
        }
        public double Price { get; set; }

        public Promotion()
        {
            promotionItems = new Dictionary<Product, int>();
            Price = 0;
        }
        public void addPromotionItem(Product product, int qunt)
        {
            promotionItems.Add(product, qunt);

        }



        /*public override string ToString()
        {
            int  val = 0;
            string res = "";
            foreach(Product item in promotionItems.Keys)
            {
                promotionItems.TryGetValue(item, out val);
                res += $"{item.ToString()}::{val}";
            }
            res += $"-{Price}";
            return res;
        }*/
    }
}
