using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Store.Tests
{
    public class OrderTests
    {
        [Fact]
        public void Order_WithEmptyList_ThrowsArgumentNullExeption()
        {


            Assert.Throws<ArgumentNullException>(() => new Order(0, null));


        }

        [Fact]
        public void Order_CountWithListOfOrderItem_ReturnZero()
        {
            var Order = new Order(0, new OrderItem[0]);

            Assert.Equal(0, Order.TotalCount);
        }

        [Fact]
        public void Order_SummWithZeroListOrderItems_ReturnZeroSumm()
        {
            var order = new Order(0, new OrderItem[0]);


            Assert.Equal(0m, order.TotalSumm);
        }

        [Fact]
        public void Order_SummWithNonEmptyList_ReturnSumm()
        {
            var orderitems = new OrderItem(0, 5, 20m);

            var order = new Order(0, new[]
            {
                new OrderItem(0,5,20m),
                new OrderItem(0,4,10m)
            })  ;


            Assert.Equal(140m, order.TotalSumm);

                
        }
        
        
        [Fact]
        public void Order_CountWithNonEmptyList_ReturnCount()
        {
            var orderitems = new OrderItem(0, 5, 20m);

            var order = new Order(0, new[]
            {
                new OrderItem(0,5,20m),
                new OrderItem(0,4,10m)
            })  ;


            Assert.Equal(9m, order.TotalCount);
                
        }

        [Fact]
        public void Order_AddItemWithNull_ThrowNullArgumentExeption()
        {


            Assert.Throws<ArgumentNullException>(() =>
            {
                Order order = new Order(0, new OrderItem[0]);

                order.AddItem(null, 0);

            });


        }

        [Fact]
        public void Order_AddItem_EqualWithBookPriceInOrder()
        {
            Order order = new Order(0, new OrderItem[0]);

            order.AddItem(new Book("", "", "", 2, 54m, ""),2);

            Assert.Equal(108m, order.TotalSumm);

        }

        [Fact]
        public void Order_AddItemWithExistingBool_EqualWithNewCountOfAddedBooks()
        {
            Order order = new Order(0, new OrderItem[0]);

            order.AddItem(new Book("", "", "", 2, 54m, ""), 2);

            order.AddItem(new Book("", "", "", 2, 54m, ""), 5);

            Assert.Equal(5, order.TotalCount);


        }





    }
}
