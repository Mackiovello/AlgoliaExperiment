using BookFinder.Domain;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookFinder.Models
{
    public class BookType : ObjectType<Book>
    {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(a => a.Title)
                .Type<NonNullType<StringType>>();
        }
    }
}
