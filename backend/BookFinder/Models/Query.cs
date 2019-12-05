using BookFinder.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookFinder.Models
{
    public class Query
    {
        private readonly IQueryAllHandler<Book> _booksQuery;

        public Query(IQueryAllHandler<Book> booksQuery)
        {
            _booksQuery = booksQuery;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _booksQuery.ExecuteAsync();
        }

        public async Task<Book> GetBookAsync(int id)
        {
            var allBooks = await _booksQuery.ExecuteAsync();
            
            // TODO: Use query to get books by ID
            return allBooks.First();
        }
    }
}
