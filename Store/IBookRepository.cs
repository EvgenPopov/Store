using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    public interface IBookRepository
    {
        Book[] GetAllByAuthorOrTitle(string titlePart);

        Book[] GetAllByIsbn(string isbn);

        Book GetById(int id);
        Book[] GetAllByIds(IEnumerable<int> booksId);
    }
}
