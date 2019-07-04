using MediatR;

namespace VinilEcommerce.Infrastructure.Data.Query.Queries.GetDisksByGenre
{
    public sealed class GetDisksByGenreCommand : IRequest<GetDisksByGenreCommandResponse>
    {
        public string Genre { get; set; }

        public int Page { get; set; }

        public int RecordsNumber { get; set; }
    }
}
