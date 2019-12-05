using BookFinder.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookFinder.Elastic
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddData(
            this IServiceCollection services,
            ElasticSettings elasticSettings)
        {
            return services
                .AddTransient(_ => elasticSettings)
                .AddTransient<BookClientFactory>()
                .AddTransient<ICommandHandler<BooksInsertCommand>, InsertBooksCommandHandler>()
                .AddTransient<IQueryAllHandler<Book>, QueryAllBooksHandler>();
        }
    }
}
