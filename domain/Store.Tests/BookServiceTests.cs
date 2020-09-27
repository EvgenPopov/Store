using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Store.Tests
{
    public class BookServiceTests
    {
        // Тест с помошью мока
        //[Fact]
        // public void GetAllByQuerry_WithISBN_CallsGetAllByIsbn()
        //{
        //    var bookRepositoryStub = new Mock<IBookRepository>();

        //    bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>())).Returns(new[] { new Book("", "", "", 1) }); //заглушка, если мы вызываем метод, то при передачи туда любой строки создается массив

        //    bookRepositoryStub.Setup(x => x.GetAllByAuthorOrTitle(It.IsAny<string>())).Returns(new[] { new Book("", "", "", 2) });

        //    var bookservice = new BookService(bookRepositoryStub.Object);

        //    var validIsbn = "ISBN 12345-67890";

        //    var actual = bookservice.GetAllByQuery(validIsbn);

        //    Assert.Collection(actual, book => Assert.Equal(1, book.Id));

        //}

        //public void GetAllByQuerry_WithISBN_CallsGetAllByAuthor()
        //{
        //    var bookRepositoryStub = new Mock<IBookRepository>();

        //    bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>())).Returns(new[] { new Book("", "", "", 1) }); //заглушка, если мы вызываем метод, то при передачи туда любой строки создается массив

        //    bookRepositoryStub.Setup(x => x.GetAllByAuthorOrTitle(It.IsAny<string>())).Returns(new[] { new Book("", "", "", 2) });

        //    var bookservice = new BookService(bookRepositoryStub.Object);

        //    var invalidIsbn = " 12345-67890";

        //    var actual = bookservice.GetAllByQuery(invalidIsbn);

        //    Assert.Collection(actual, book => Assert.Equal(2, book.Id));

        //}

        [Fact]
        public void GetAllByQuerry_WithISBN_CallsGetAllByIsbn()
        {

            const int idOfIsbnSearch = 1;
            const int IdOfAuthorOrTitleSearch = 2;



            var bookRepository = new StubBookRepository();

            bookRepository.ResultOfGetAllByAuthorOrTitle = new[]
            {
                new Book("","","",IdOfAuthorOrTitleSearch, 0m, "")
            };

            bookRepository.ResultOfGetAllByIsbn = new[]
            {
                new Book("","","",idOfIsbnSearch, 0m, "")
            };

            var bookService = new BookService(bookRepository);

            var books = bookService.GetAllByQuery("ISBN 01234-56789");

            Assert.Collection(books, book => Assert.Equal(idOfIsbnSearch, book.Id));
        }

        [Fact]
        public void GetAllByQuerry_WithISBN_CallsGetAllByAuthor()
        {

            const int idOfIsbnSearch = 1;
            const int IdOfAuthorOrTitleSearch = 2;



            var bookRepository = new StubBookRepository();

            bookRepository.ResultOfGetAllByAuthorOrTitle = new[]
            {
                new Book("","","",IdOfAuthorOrTitleSearch, 0m, "")
            };

            bookRepository.ResultOfGetAllByIsbn = new[]
            {
                new Book("","","", idOfIsbnSearch, 0m, "")
            };

            var bookService = new BookService(bookRepository);

            var books = bookService.GetAllByQuery("Koen");

            Assert.Collection(books, book => Assert.Equal(IdOfAuthorOrTitleSearch, book.Id));
        }


    }
}
