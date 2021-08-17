using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Model;

namespace PromotionEngineTest
{
    [TestClass]
    public class LineItemTest
    {
        [TestMethod]
        public void ProductTest_ToString()
        {
            Product p1 = new Product('A' , 50);
            LineItem l1 = new LineItem(p1, 5);
            Assert.AreEqual("A-5", l1.ToString());
        }
    }
}
