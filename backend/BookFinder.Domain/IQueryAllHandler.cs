using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookFinder.Domain
{
    public interface IQueryAllHandler<T>
    {
        Task<IEnumerable<T>> ExecuteAsync();
    }
}
