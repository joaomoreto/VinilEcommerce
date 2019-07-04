using AutoMapper;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Services.Sales;
using VinilEcommerce.Infrastructure.Data.Query.Queries.GetSalesById;

namespace VinilEcommerce.Infrastructure.Data.Query.MapperProfiles
{
    public sealed class GetSalesByIdCommandResponseProfile : Profile
    {
        public GetSalesByIdCommandResponseProfile()
        {
            CreateMap<SalesDataBaseResponse, GetSalesByIdCommandResponse>(MemberList.None);
        }
    }
}
