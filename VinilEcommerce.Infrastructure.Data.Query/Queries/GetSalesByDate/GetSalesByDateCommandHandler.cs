using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Interfaces;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Services.Sales;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Services.Spotify;

namespace VinilEcommerce.Infrastructure.Data.Query.Queries.GetSalesByDate
{
    public sealed class GetSalesByDateCommandHandler :
        IRequestHandler<GetSalesByDateCommand, GetSalesByDateCommandResponse>
    {
        private readonly IDisksDataBase _disksDataBase;
        private readonly IMapper _mapper;

        public GetSalesByDateCommandHandler(
            IDisksDataBase disksDataBase,
            IMapper mapper)
        {
            _disksDataBase = disksDataBase;
            _mapper = mapper;
        }

        public async Task<GetSalesByDateCommandResponse> Handle(GetSalesByDateCommand request, CancellationToken cancellationToken)
        {
            var results = _disksDataBase.GetSalesByDate(new SpotifyDateDataBaseRequest
            {
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Page = request.Page,
                RecordsNumber = request.RecordsNumber
            });

            var response = new GetSalesByDateCommandResponse
            {
                Sales = _mapper.Map<IEnumerable<SalesDataBaseResponse>,
                    IEnumerable<GetSalesByDateCommandResponse.Sale>>(results)
            };

            return response;
        }
    }
}
