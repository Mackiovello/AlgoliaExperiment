using BookFinder.Domain;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookFinder.Elastic
{
    class QueryAllBooksHandler : IQueryAllHandler<Book>
    {
        private readonly IElasticClient _elasticClient;

        public QueryAllBooksHandler(BookClientFactory clientFactory)
        {
            _elasticClient = clientFactory.Create();
        }

        public async Task<IEnumerable<Book>> ExecuteAsync()
        {
            var response = await _elasticClient.SearchAsync<Book>(s => s);

            if (!response.IsValid)
            {
                throw new InvalidOperationException("Search for books failed");
            }

            return response.Documents;
        }
    }
}
