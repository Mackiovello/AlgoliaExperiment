using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookFinder.Domain
{
    public interface ICommandHandler<in TCommand>
    {
        Task ExecuteAsync(TCommand command);
    }
}
