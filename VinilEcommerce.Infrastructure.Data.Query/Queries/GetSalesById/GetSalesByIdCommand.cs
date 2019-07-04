using MediatR;

namespace VinilEcommerce.Infrastructure.Data.Query.Queries.GetSalesById
{
    public sealed class GetSalesByIdCommand : IRequest<GetSalesByIdCommandResponse>
    {
        public int Id { get; set; }
    }
}
