using BookFinder.Domain;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookFinder.Elastic
{
    class InsertBooksCommandHandler : ICommandHandler<BooksInsertCommand>
    {
        private readonly IElasticClient _elasticClient;
        public InsertBooksCommandHandler(BookClientFactory clientFactory)
        {
            _elasticClient = clientFactory.Create();
        }

        public async Task ExecuteAsync(BooksInsertCommand command)
        {
            var response = await _elasticClient.IndexManyAsync(command.Books);

            if (!response.IsValid)
            {
                throw new InvalidOperationException("Insert books failed");
            }
        }
    }
}
