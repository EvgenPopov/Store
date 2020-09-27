using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store
{
    public class Order
    {
        public int Id { get; }

        private List<OrderItem> items;

        public IReadOnlyCollection<OrderItem> Items
        {
            get { return Items; }
        }

        public int TotalCount
        {
            get { return items.Sum(item => item.Count); }
        }

        public decimal TotalSumm
        {
            get { return items.Sum(item => item.Price * item.Count); }
        }


        public Order (int id, IEnumerable<OrderItem> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));


            Id = id;

            this.items = new List<OrderItem>(items);
        }


        public void AddItem(Book book, int count)
        {
            if (book is null)
                throw new ArgumentNullException(nameof(book));

            var item = items.SingleOrDefault(i => i.BookId == book.Id); //проверка, есть ли книжка в списке

            if(item is null)
            {
                items.Add(new OrderItem(book.Id,count,book.Price));
            }
            else
            {
                items.Remove(item);
                items.Add(new OrderItem(book.Id, item.Count+count, book.Price));
            }    

            



        }




    }
}
