using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Model;

namespace ShoppingCartTest
{
    [TestClass]
    public class PromotionTest
    {
        [TestMethod]
        public void PromotionTest_ToString_positive_checkreturning_validString()
        {
            Product p1 = new Product('A', 50);
            LineItem l1 = new LineItem(p1, 5);
            Promotion pn = new Promotion();
            pn.addPromotionItem(p1, 3);
            pn.Price = 130;
            Assert.AreEqual(130, pn.Price);
            Assert.AreEqual(1, pn.PromotionItems.Count);
            int value = 0;
            pn.PromotionItems.TryGetValue(p1, out value);
            Assert.AreEqual(3, value);
        }
    }
}
