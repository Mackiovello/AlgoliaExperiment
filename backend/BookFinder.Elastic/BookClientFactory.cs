using Nest;
using System;

namespace BookFinder.Elastic
{
    public class BookClientFactory
    {
        private readonly ElasticSettings _settings;

        public BookClientFactory(ElasticSettings settings)
        {
            _settings = settings;
        }

        public IElasticClient Create()
        {
            using var connectionSettings = new ConnectionSettings(new Uri(_settings.Url))
                .DefaultIndex("books");
            return new ElasticClient(connectionSettings);
        }
    }
}
