using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookFinder.Models
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(q => q.GetBooksAsync())
                .Type<NonNullType<ListType<NonNullType<BookType>>>>();

            descriptor.Field(q => q.GetBookAsync(default))
                .Argument("id", a => a.Type<NonNullType<IdType>>());
        }
    }
}
