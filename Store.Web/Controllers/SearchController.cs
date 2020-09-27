using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store;
using Store.Memory;

namespace Store.Web.Controllers
{
    public class SearchController : Controller
    {
        //private readonly IBookRepository bookRepository; - Старая версия

        private readonly BookService bookService;


        public SearchController (BookService bookservice)
        {
            bookService = bookservice;
        }

        public IActionResult Index(string query)
        {
            var books = bookService.GetAllByQuery(query);

            return View(books);
        }



    }
}
