using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    public class OrderItem //класс для отображения одного заказа
    {
        public int BookId { get; }

        private int count;

        public int Count
        {
            get { return count; }

            set
            {
                ThrowIfInvalidExeption(value);

                count = value;
            }

        }

        private static void ThrowIfInvalidExeption(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("Count must be grater than zero");
        }

        public decimal Price { get; }

        public OrderItem(int bookid, int count, decimal price)
        {

            ThrowIfInvalidExeption(count);
       

            BookId = bookid;

            Count = count;

            Price = price;
        }

    }
}
