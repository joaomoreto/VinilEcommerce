using MediatR;

namespace VinilEcommerce.Infrastructure.Data.Query.Queries.GetDisksById
{
    public sealed class GetDisksByIdCommand : IRequest<GetDisksByIdCommandResponse>
    {
        public int Id { get; set; }
    }
}
