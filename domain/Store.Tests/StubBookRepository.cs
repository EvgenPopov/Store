using System.Collections.Generic;

namespace Store.Tests
{
    class StubBookRepository : IBookRepository //ручная заглушка для проведения тестов
    {

        public Book[] ResultOfGetAllByAuthorOrTitle { get; set; }
        public Book[] ResultOfGetAllByIsbn { get; set; }


        public Book[] GetAllByAuthorOrTitle(string titlePart)
        {
            return ResultOfGetAllByAuthorOrTitle;
        }

        public object GetAllByIds(IEnumerable<int> booksId)
        {
            throw new System.NotImplementedException();
        }

        public Book[] GetAllByIsbn(string isbn)
        {
           return ResultOfGetAllByIsbn;
        }

        public Book GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
