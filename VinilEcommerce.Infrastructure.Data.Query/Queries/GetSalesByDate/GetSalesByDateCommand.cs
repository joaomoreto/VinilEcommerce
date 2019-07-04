using System;
using MediatR;

namespace VinilEcommerce.Infrastructure.Data.Query.Queries.GetSalesByDate
{
    public sealed class GetSalesByDateCommand : IRequest<GetSalesByDateCommandResponse>
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Page { get; set; }

        public int RecordsNumber { get; set; }
    }
}
