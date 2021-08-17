using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Model;
using ShoppingCart.Engine;
using System.Collections.Generic;

namespace ShoppingCartTest
{
    [TestClass]
    public class PricingEngineTest
    {
        Product p1, p2, p3, p4;
        Promotion po1, po2, po3, po4;

        [TestInitialize]
        public void testInit()
        {
            p1 = new Product('A', 50);
            p2 = new Product('B', 30);
            p3 = new Product('C', 20);
            p4 = new Product('D', 15);
            po1 = new Promotion();
            po1.addPromotionItem(p1, 3); po1.Price = 130;
            po2 = new Promotion();
            po2.addPromotionItem(p2, 2); po2.Price = 45;
            po3 = new Promotion();
            po3.addPromotionItem(p3, 1); po3.Price = 30;
            po3.addPromotionItem(p4 , 1);
        }

        [TestMethod]
        public void PriceEngineTest_Case1()
        {
            Order ord = new Order();
            ord.addLineItem(p1, 1);
            ord.addLineItem(p2, 1);
            ord.addLineItem(p3, 1);
            PricingEngine engine = new PricingEngine();
            engine.Cart = ord;
            engine.addPromotion(po1);
            engine.addPromotion(po2);
            engine.addPromotion(po3);
            engine.applyPromotion();
            Assert.AreEqual(0, engine.Cart.PromotionAppliedLineItems.Count);
            Assert.AreEqual(0, engine.Cart.Price);
            engine.CalculatePrice();
            Assert.AreEqual(100, engine.Cart.Price);
        }

        [TestMethod]
        public void PriceEngineTest_Case2()
        {
            Order ord = new Order();
            ord.addLineItem(p1, 5);
            ord.addLineItem(p2, 5);
            ord.addLineItem(p3, 1);
            int tmp = 0;
            PricingEngine engine = new PricingEngine();
            engine.Cart = ord;
            engine.addPromotion(po1);
            engine.addPromotion(po2);
            engine.addPromotion(po3);
            engine.applyPromotion();
            Assert.AreEqual(2, engine.Cart.PromotionAppliedLineItems.Count);
            engine.Cart.PromotionAppliedLineItems.TryGetValue(p1, out tmp);
            Assert.AreEqual(3, tmp);
            tmp = 0;
            engine.Cart.PromotionAppliedLineItems.TryGetValue(p2, out tmp);
            Assert.AreEqual(4, tmp);
            Assert.AreEqual(130 + 45 + 45, engine.Cart.Price);
            engine.CalculatePrice();
            Assert.AreEqual(370, engine.Cart.Price);
        }

        [TestMethod]
        public void PriceEngineTest_Case3()
        {
            Order ord = new Order();
            ord.addLineItem(p1, 3);
            ord.addLineItem(p2, 5);
            ord.addLineItem(p4, 1);
            int tmp = 0;
            PricingEngine engine = new PricingEngine();
            engine.Cart = ord;
            engine.addPromotion(po1);
            engine.addPromotion(po2);
            engine.addPromotion(po3);
            engine.applyPromotion();
            Assert.AreEqual(2, engine.Cart.PromotionAppliedLineItems.Count);
            engine.Cart.PromotionAppliedLineItems.TryGetValue(p1, out tmp);
            Assert.AreEqual(3, tmp);
            tmp = 0;
            engine.Cart.PromotionAppliedLineItems.TryGetValue(p2, out tmp);
            Assert.AreEqual(4, tmp);
            Assert.AreEqual(130 + 45 + 45, engine.Cart.Price);
            engine.CalculatePrice();
            Assert.AreEqual(265, engine.Cart.Price);
        }




    }
}
