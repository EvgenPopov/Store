using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Store.Tests
{
    public class OrderItemTests
    {
        [Fact]
        public void OrdreItem_WithZeroCount_ThrowArgumentOutOfRangeExeption()
        {
            const int ZeroCount = 0;

            Assert.Throws<ArgumentOutOfRangeException>(() => new OrderItem(1, ZeroCount, 0m));


        }

        [Fact]
        public void OrderItem_WithRightCount_NormalSetCountInObject()
        {

            int count = 1;


            var order = new OrderItem(1, count, 2m);

            Assert.Equal(1, order.Count);        

        }


        [Fact]
        public void Count_WithNegativeValue_ThrowsArgumentOfRangeException()
        {
            var orderItem = new OrderItem(0, 5, 0m);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                orderItem.Count = -1;
            });
        }

        [Fact]
        public void Count_WithZeroValue_ThrowsArgumentOfRangeException()
        {
            var orderItem = new OrderItem(0, 5, 0m);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                orderItem.Count = 0;
            });
        }

        [Fact]
        public void Count_WithPositiveValue_SetsValue()
        {
            var orderItem = new OrderItem(0, 5, 0m);

            orderItem.Count = 10;

            Assert.Equal(10, orderItem.Count);
        }

    }
}
       