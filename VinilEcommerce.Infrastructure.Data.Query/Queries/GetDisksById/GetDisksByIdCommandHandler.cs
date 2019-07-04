using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Interfaces;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Services.Spotify;

namespace VinilEcommerce.Infrastructure.Data.Query.Queries.GetDisksById
{
    public sealed class GetDisksByIdCommandHandler :
        IRequestHandler<GetDisksByIdCommand, GetDisksByIdCommandResponse>
    {
        private readonly IDisksDataBase _disksDataBase;
        private readonly IMapper _mapper;

        public GetDisksByIdCommandHandler(
            IDisksDataBase disksDataBase,
            IMapper mapper)
        {
            _disksDataBase = disksDataBase;
            _mapper = mapper;
        }

        public async Task<GetDisksByIdCommandResponse> Handle(GetDisksByIdCommand request, CancellationToken cancellationToken)
        {
            var disk = _disksDataBase.GetDisksById(request.Id);

            var response = _mapper.Map<SpotifyDataBaseResponse, GetDisksByIdCommandResponse>(disk);

            return response;
        }
    }
}
