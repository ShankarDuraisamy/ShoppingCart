using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Model;

namespace ShoppingCartTest
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void ProductTest_ToString()
        {
            Product p1 = new Product('A' , 50);
            LineItem l1 = new LineItem(p1, 5);
            Assert.AreEqual("A", p1.ToString());
        }
    }
}
