using System;
using Xunit;

namespace Store.Tests
{
    public class BookTests
    {
        [Fact]
        public void IsIsbn_WithNull_ReturnFalse() // в качестве рекомендаций записывают именно так, мы передаем null в качестве параметра и этот медод должен вернуть Fasle
        {
            bool actual = Book.IsIsbn(null);

            Assert.False(actual);
        }   

        [Fact]
        public void IsIsbn_WithBlankString_ReturnFalse()
        {
            bool actual = Book.IsIsbn("    ");

            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_WithInvalidISBN_ReturnFalse() 
        {
            bool actual = Book.IsIsbn("ISBN 1234");

            Assert.False(actual);
        }
        
        [Fact]
        public void IsIsbn_WithISBN10_ReturnTrue() 
        {
            bool actual = Book.IsIsbn("ISBN 1234567890");

            Assert.True(actual);
        }
        
        [Fact]
        public void IsIsbn_TrashStart_ReturnFalse()
        {

            bool actual = Book.IsIsbn("Eres Isbn 102102312341 ds;flkdsf");

            Assert.False(actual);

        }


    }
}
