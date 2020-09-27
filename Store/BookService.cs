using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    public class BookService //этот класс выбирает, что именоо будет искаться либо по ISBN либо по названию книги и автору.
    {

        private readonly IBookRepository bookRepository;
         

        public BookService (IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public Book[] GetAllByQuery(string query)
        {
            if (Book.IsIsbn(query))
                return bookRepository.GetAllByIsbn(query);

            return bookRepository.GetAllByAuthorOrTitle(query);

        }
    }
}
