using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Model;

namespace ShoppingCartTest
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void OrderTest_AddLineItem_NewLineItem()
        {
            Product p1 = new Product('A', 50);
            int qnt = 10;
            Order ord = new Order();
            ord.addLineItem(p1, qnt);
            Assert.AreEqual(1, ord.LineItems.Count);
            int value = 0;
            ord.LineItems.TryGetValue(p1, out value);
            Assert.AreEqual(10, value);
        }
        [TestMethod]
        public void OrderTest_AddLineItem_ExistingLineItem()
        {
            Product p1 = new Product('A', 50);
            int qnt = 10;
            Order ord = new Order();
            ord.addLineItem(p1, qnt);
            ord.addLineItem(p1, qnt);
            Assert.AreEqual(1, ord.LineItems.Count);
            int value = 0;
            ord.LineItems.TryGetValue(p1, out value);
            Assert.AreEqual(20, value);
        }

        [TestMethod]
        public void OrderTest_AddPromotionalLineItem_NewLineItem()
        {
            Product p1 = new Product('A', 50);
            int qnt = 10;
            Order ord = new Order();
            ord.addPromotionAppliedLineItem(p1, qnt);
            Assert.AreEqual(1, ord.PromotionAppliedLineItems.Count);
            int value = 0;
            ord.PromotionAppliedLineItems.TryGetValue(p1, out value);
            Assert.AreEqual(10, value);
        }

        [TestMethod]
        public void OrderTest_AddPromotionalLineItem_ExistingLineItem()
        {
            Product p1 = new Product('A', 50);
            int qnt = 10;
            Order ord = new Order();
            ord.addPromotionAppliedLineItem(p1, qnt);
            ord.addPromotionAppliedLineItem(p1, qnt);
            Assert.AreEqual(1, ord.PromotionAppliedLineItems.Count);
            int value = 0;
            ord.PromotionAppliedLineItems.TryGetValue(p1, out value);
            Assert.AreEqual(20, value);
        }

        [TestMethod]
        public void OrderTest_LabelPrice_Calculation()
        {
            Product p1 = new Product('A', 50);
            Product p2 = new Product('B', 10);
            int qnt = 10;
            Order ord = new Order();
            ord.addLineItem(p1, qnt);
            ord.addLineItem(p2, qnt);
            Assert.AreEqual(600, ord.LabelPrice);
        }


        [TestMethod]
        public void OrderTest_addPrice_Calculation()
        {
            int price = 500;
            Order ord = new Order();
            ord.Price = 100;
            ord.addPrice(price);
            Assert.AreEqual(600, ord.Price);
        }
        
    }
}
