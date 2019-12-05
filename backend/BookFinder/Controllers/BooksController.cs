using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookFinder.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BookFinder.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly AdlibrisScraper _adlibrisScraper;
        private readonly ICommandHandler<BooksInsertCommand> _booksInserter;

        public BooksController(AdlibrisScraper adlibrisScraper, ICommandHandler<BooksInsertCommand> booksInserter)
        {
            _adlibrisScraper = adlibrisScraper;
            _booksInserter = booksInserter;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var titles = await _adlibrisScraper.FindTitles();

            var books = titles.Select(t => new Book() { Title = t });
            await _booksInserter.ExecuteAsync(new BooksInsertCommand(books));
            return titles;
        }
    }
}
