using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate
{
    internal class Library
    {
        public List<Book> Books = new List<Book>();
        
        public void AddBook(Book book)
        {
            Books.Add(book);
        }
        public List<Book> FilterByPrice(double minPrice, double maxPrice)
        {
            return Books.FindAll(x => x.Price >= minPrice && x.Price <= maxPrice);
        }
        public List<Book> FilterByGenre(BookGenre genre)
        {
            return Books.FindAll(x => x.Genre == genre);
        }
        public Book FindBookByNo(int no)
        {
            return Books.Find(x => x.No == no);
        }
        public bool IsExistBookByNo(int no)
        {
            return Books.Exists(x => x.No == no);
        }
        public List<Book> RemoveAll(Predicate<Book> predicate)
        {
            Books.RemoveAll(predicate);
            return Books;
        }
    }
}
