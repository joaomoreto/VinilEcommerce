using System.Collections.Generic;
using MediatR;

namespace VinilEcommerce.Domain.Commands.SellDisks
{
    public sealed class SellDisksCommand : IRequest
    {
        public IEnumerable<int> Ids { get; set; }
    }
}
