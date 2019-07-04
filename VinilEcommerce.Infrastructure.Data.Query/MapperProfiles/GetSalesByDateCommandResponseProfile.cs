using AutoMapper;
using System.Collections.Generic;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Services.Sales;
using VinilEcommerce.Infrastructure.Data.Query.Queries.GetSalesByDate;

namespace VinilEcommerce.Infrastructure.Data.Query.MapperProfiles
{
    public sealed class GetSalesByDateCommandResponseProfile : Profile
    {
        public GetSalesByDateCommandResponseProfile()
        {
            CreateMap<SalesDataBaseResponse, GetSalesByDateCommandResponse.Sale>(MemberList.None);
        }
    }
}
