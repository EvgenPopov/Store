using System;
using System.Collections.Generic;
using System.Linq;
using Store;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {

        private readonly Book[] books = new[]
        {
           new Book("Art of Programming","ISBN 13312-31323", "D. Knuth", 1, 7.19m , "Занимательная книга о программировании" ),
           new Book("Refactoring","ISBN 12352-31323", "M. Fowler", 2, 12.45m , "Рефакторинг - как состовляющая вашей ублюдочной жизни"),
           new Book("C Programming Language", "ISBN 12314-31323", "D. Ritchie", 3, 14.98m , "Всё о языке СИ ПЛЮС ПЛЮС")

       };

        public Book[] GetAllByAuthorOrTitle(string query)
        {


                return books.Where(book => book.Title.Contains(query) 
                                        || book.Autor.Contains(query))
                    .ToArray();


        }

        public Book[] GetAllByIds(IEnumerable<int> bookIds)
        {
            var foundBooks = from book in books
                             join bookId in bookIds on book.Id equals bookId
                             select book;

            return foundBooks.ToArray();
        }


        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.ISBN.Contains(isbn)).ToArray();
        }

        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }
    }
}
