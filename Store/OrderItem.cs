using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    public class OrderItem //класс для отображения одного заказа
    {
        public int BookId { get; }

        public int Count { get; }

        public decimal Price { get; }

        public OrderItem(int bookid, int count, decimal price)
        {

            if (count <= 0)
                throw new ArgumentOutOfRangeException("Count must be more than null");

            BookId = bookid;

            Count = count;

            Price = price;
        }

    }
}
