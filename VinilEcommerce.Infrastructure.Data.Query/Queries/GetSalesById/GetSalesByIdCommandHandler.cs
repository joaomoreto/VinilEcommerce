using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Interfaces;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Services.Sales;

namespace VinilEcommerce.Infrastructure.Data.Query.Queries.GetSalesById
{
    public sealed class GetSalesByIdCommandHandler :
        IRequestHandler<GetSalesByIdCommand, GetSalesByIdCommandResponse>
    {
        private readonly IDisksDataBase _disksDataBase;
        private readonly IMapper _mapper;

        public GetSalesByIdCommandHandler(
            IDisksDataBase disksDataBase,
            IMapper mapper)
        {
            _disksDataBase = disksDataBase;
            _mapper = mapper;
        }

        public async Task<GetSalesByIdCommandResponse> Handle(GetSalesByIdCommand request, CancellationToken cancellationToken)
        {
            var venda = _disksDataBase.GetSalesById(request.Id);

            var response = _mapper.Map<SalesDataBaseResponse, GetSalesByIdCommandResponse>(venda);

            return response;
        }
    }
}
