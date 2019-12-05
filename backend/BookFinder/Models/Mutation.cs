using BookFinder.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookFinder.Models
{
    public class Mutation
    {
        public async Task<Book> SubmitBook(SubmitBookInput input)
        {
            var book = new Book()
            {
                Title = input.Title
            };

            // Save book to storage

            return await Task.FromResult(book);
        }
    }

    public class SubmitBookInput
    {
        public string Title { get; set; }
    }
}
