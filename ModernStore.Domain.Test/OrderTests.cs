using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;

namespace ModernStore.Domain.Test
{
    [TestClass]
    public class OrderTests
    {
        //[TestMethod]
        //[TestCategory("Order - New Order")]
        //public void GivenAnOutOfStockProductItShouldReturnAnError()
        //{
        //    var user = new User("marcelo", "1234");
        //    var customer = new Customer("Marcelo", "Silva", new System.DateTime(1984, 07, 18), "marcelo@teste.com", user);
        //    var mouse = new Product("Mouse", 299, "mouse.jpg", 0);            
        //    var order = new Order(customer, 8, 10);
        //    order.AddItem(new OrderItem(mouse, 2));

        //    Assert.IsFalse( order.IsValid());
            
        //}
        //[TestMethod]
        //[TestCategory("Order - New Order")]
        //public void GivenAnInStockProductItShouldUpdateQuantityOnHand()
        //{
        //    var user = new User("marcelo", "1234");
        //    var customer = new Customer("Marcelo", "Silva", new System.DateTime(1984, 07, 18), "marcelo@teste.com", user);
        //    var mouse = new Product("Mouse", 299, "mouse.jpg", 20);
        //    var order = new Order(customer, 8, 10);
        //    order.AddItem(new OrderItem(mouse, 2));

        //    Assert.IsTrue(mouse.QuantityOnHand==18);

        //}

        //[TestMethod]
        //[TestCategory("Order - New Order")]
        //public void GivenAValidOrderThenShouldBe290()
        //{
        //    var user = new User("marcelo", "1234");
        //    var customer = new Customer("Marcelo", "Silva", new System.DateTime(1984, 07, 18), "marcelo@teste.com", user);
        //    var mouse = new Product("Mouse", 300, "mouse.jpg", 20);
        //    var order = new Order(customer, 12, 2);
        //    order.AddItem(new OrderItem(mouse, 1));

        //    Assert.IsTrue(order.Total() == 310);

        //}
    }
}
