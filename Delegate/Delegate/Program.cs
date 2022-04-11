using System;
using System.Collections.Generic;

namespace Delegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Neche book obyekti yaratmaq isteyirsiniz? ");
            int count = int.Parse(Console.ReadLine());
            Library library = new Library();
            int i = 1;

            while (count>0)
            {
                Console.WriteLine(i + "-ci kitabin adini daxil edin: ");
                string name = Console.ReadLine();
                Console.WriteLine(i + "-ci kitabin muellifini daxil edin: ");
                string authorName = Console.ReadLine();
                Console.WriteLine(i + "-ci kitabin qiymetini daxil edin: ");
                double price = double.Parse(Console.ReadLine());

                Book book = new Book(name, authorName, price);

                Console.WriteLine(i + "ci kitabin janrini daxil edin: \n\n");
                Console.WriteLine("=======G E N R E========");
                foreach (var item in Enum.GetValues(typeof(BookGenre)))
                {
                    Console.WriteLine((byte)item + " - " + item);
                }

                Console.WriteLine("Secim edin: ");
                string typeStr = Console.ReadLine();
                byte typeByte;

                while(!byte.TryParse(typeStr, out typeByte))
                {
                    Console.WriteLine("Eded daxil edin: ");
                    typeStr = Console.ReadLine();
                }
                while (!Enum.IsDefined(typeof(BookGenre),typeByte))
                {
                    Console.WriteLine("Dogru secim edin: ");
                    typeStr = Console.ReadLine();
                    while (!byte.TryParse(typeStr, out typeByte))
                    {
                        Console.WriteLine("Eded daxil edin: ");
                        typeStr = Console.ReadLine();
                    }
                    typeByte = Convert.ToByte(typeStr);
                }

                BookGenre selectedGenre = (BookGenre)typeByte;

                book.Genre = selectedGenre;

                library.AddBook(book);

                count--;
                i++;
            }

            Console.WriteLine("==================");
            foreach (var item in library.FilterByPrice(10, 20))
            {
                Console.WriteLine(item.No + " " +  item.Name + " " + item.AuthorName + " " + item.Genre + " " + item.Price);
            }
            Console.WriteLine("==================");
            foreach (var item in library.FilterByGenre(BookGenre.Adventure))
            {
                Console.WriteLine(item.No + " " + item.Name + " " + item.AuthorName + " " + item.Genre + " " + item.Price);
            }
            Console.WriteLine("==================");
            Book findedBook = library.FindBookByNo(2);
            Console.WriteLine(findedBook.Name);
            Console.WriteLine(library.IsExistBookByNo(1));
            Console.WriteLine("==================");

            List<Book> RemovedBooks = library.RemoveAll(x => x.Price >= 15);

            foreach (var item in RemovedBooks)
            {
                Console.WriteLine(item.No + " " + item.Name + " " + item.AuthorName + " " + item.Genre + " " + item.Price);
            }

        }
    }
}
