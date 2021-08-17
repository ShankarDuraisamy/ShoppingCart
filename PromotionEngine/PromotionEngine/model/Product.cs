using System;

namespace ShoppingCart.Model
{
    public class Product
    {
        public Product(char productID, double unitPrice)
        {
            ProductID = productID;
            UnitPrice = unitPrice;
        }
        public char ProductID { get; set; }
        public double UnitPrice { get; set; }

        public override string ToString()
        {
            return $"{ProductID}";
        }


    }
}
