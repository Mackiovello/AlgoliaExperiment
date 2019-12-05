using System;
using System.Collections.Generic;

namespace BookFinder.Domain
{
    public class BooksInsertCommand
    {
        public BooksInsertCommand(IEnumerable<Book> books)
        {
            Books = books;
        }

        public IEnumerable<Book> Books { get; }
    }
}
