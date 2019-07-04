using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Interfaces;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Services.Spotify;

namespace VinilEcommerce.Infrastructure.Data.Query.Queries.GetDisksByGenre
{
    public sealed class GetDisksByGenreCommandHandler :
        IRequestHandler<GetDisksByGenreCommand, GetDisksByGenreCommandResponse>
    {
        private readonly IDisksDataBase _disksDataBase;
        private readonly IMapper _mapper;

        public GetDisksByGenreCommandHandler(
            IDisksDataBase disksDataBase, 
            IMapper mapper)
        {
            _disksDataBase = disksDataBase;
            _mapper = mapper;
        }

        public async Task<GetDisksByGenreCommandResponse> Handle(GetDisksByGenreCommand request, CancellationToken cancellationToken)
        {
            var results = _disksDataBase.GetDisksByGenre(new SpotifyGenreDataBaseRequest
            {
                Genre = request.Genre,
                Page = request.Page,
                RecordsNumber = request.RecordsNumber
            });

            var response = new GetDisksByGenreCommandResponse
            {
                Disks = _mapper.Map<IEnumerable<SpotifyDataBaseResponse>, 
                    IEnumerable<GetDisksByGenreCommandResponse.Disk>>(results)
            };

            return response;
        }
    }
}
