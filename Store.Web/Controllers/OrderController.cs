﻿    using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Store.Web.Models;

namespace Store.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IBookRepository bookRepository;

        private readonly IOrderRepository orderRepository;

        public OrderController(IBookRepository bookRepository, IOrderRepository orderRepository)
        {
            this.bookRepository = bookRepository;
            this.orderRepository = orderRepository;
        }


        public IActionResult Index()
        {
            if (HttpContext.Session.TryGetCart(out Cart cart))
            {
                var order = orderRepository.GetById(cart.OrderId);

                OrderModel model = Map(order);


                return View(model);

            }


            //OrderItemModel orderItemModel = new OrderItemModel { Author = "Bibo", BookId = 5, Count = 1, Price = 100m, Title = "Пошёл ты нахуй урод" };

            //OrderModel orderModel = new OrderModel { Id = 2, Items = new[] { orderItemModel }, TotalCount = 1, TotalPrice = 2000m };

            //return View(orderModel);



            return View("Empty");
        }

        public OrderModel Map(Order order)
        {


            var bookIds = order.Items.Select(item => item.BookId);

            var books = bookRepository.GetAllByIds(bookIds);


            var itemModels = from item in order.Items
                             join book in books on item.BookId equals book.Id
                             select new OrderItemModel
                             {
                                 BookId = book.Id,
                                 Title = book.Title,
                                 Author = book.Autor,
                                 Price = item.Price,
                                 Count = item.Count,
                             };

            return new OrderModel
            {
                Id = order.Id,
                Items = itemModels.ToArray(),
                TotalCount = order.TotalCount,
                TotalPrice = order.TotalSumm,
            };
        }




        public IActionResult Add(int id)

        {
            
            Order order;


            if (HttpContext.Session.TryGetCart(out Cart cart)) // проверяем существует ли заказ, если нет, то создаём новый.
            {
                order = orderRepository.GetById(cart.OrderId);
            }
            else
            {
                order = orderRepository.Create();
                cart = new Cart(order.Id);
            }

            var book = bookRepository.GetById(id);
            order.AddItem(book, 1);
            orderRepository.Update(order);


            cart.TotalCount = order.TotalCount;
            cart.TotalPrice = order.TotalSumm;
            HttpContext.Session.Set(cart);

            return RedirectToAction("Index", "Book", new { id });
        }
    }
}
