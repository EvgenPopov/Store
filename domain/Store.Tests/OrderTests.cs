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
        public void GetItem_WithExistingItem_ReturnsItem()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m),
            });

            var orderItem = order.GetItem(1);

            Assert.Equal(3, orderItem.Count);
        }

        [Fact]
        public void GetItem_WithNonExistingItem_ThrowsInvalidOperationException()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m),
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                order.GetItem(100);
            });
        }

        [Fact]
        public void AddOrUpdateItem_WithExistingItem_UpdatesCount()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m),
            });

            var book = new Book(null, null, null, 1, 0m, null);

            order.AddOrUpdateItem(book, 10);

            Assert.Equal(13, order.GetItem(1).Count);
        }

        [Fact]
        public void AddOrUpdateItem_WithNonExistingItem_AddsCount()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m),
            });

            var book = new Book(null, null, null, 4, 0m, null);

            order.AddOrUpdateItem(book, 10);

            Assert.Equal(10, order.GetItem(4).Count);
        }

        [Fact]
        public void RemoveItem_WithExistingItem_RemovesItem()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m),
            });

            order.RemoveItem(1);

            Assert.Equal(1, order.Items.Count);
        }

        [Fact]
        public void RemoveItem_WithNonExistingItem_ThrowsInvalidOperationException()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m),
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                order.RemoveItem(100);
            });
        }





    }
}
