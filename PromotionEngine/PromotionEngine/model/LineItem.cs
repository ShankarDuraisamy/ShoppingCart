using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Model
{
    public class LineItem : IEquatable<LineItem>
    {
        public LineItem(Product item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }
        public Product Item { get; set; }
        public int Quantity { get; set; }
        public bool Equals(LineItem lineItem)
        {
            return lineItem.Item.ProductID == this.Item.ProductID;
        }

        public override string ToString()
        {
            return $"{Item.ToString()}-{Quantity}";
        }
        /*public override int GetHashCode()
        {
            return item.;
        }*/
    }
}
