using System;
using System.Text.RegularExpressions;

namespace Store
{
    public class Book
    {
        public string Title { get; }
        public int Id { get; }


        public string ISBN { get; }

        public string Autor { get; }

        public string Description { get;  }

        public decimal Price { get; }

        public Book(string title, string isbn, string autor, int id, decimal price, string descr)
        {
            Title = title;
            Id = id;
            Price = price;
            Description = descr;
            ISBN = isbn;

            Autor = autor;
        }

        internal static bool IsIsbn(string s)
        {
            if (s == null)
                return false;

            s = s.Replace("-", "")
                .Replace(" ", "")
                .ToUpper();

            return Regex.IsMatch(s, @"^ISBN\d{10}(\d{3})?$"); //Метод который возвращает ТРУ если находит указанные символы, двойно слэш и d(decimal) ^ - если стоит такое то значит выражение должно стопроц начинаться с ИСБн

        }


    }
}
