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


    }
}
