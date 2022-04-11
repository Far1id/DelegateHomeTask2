using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate
{
    internal class Book
    {
        public Book(string name, string authorName, double price)
        {
            Name = name;
            AuthorName = authorName;
            Price = price;
            _no++;
            No = _no;
        }
        static int _no;
        public int No { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public BookGenre Genre { get; set; }
        public double Price { get; set; }
    }
}
