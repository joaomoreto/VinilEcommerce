using AutoFixture;
using AutoMapper;
using NSubstitute;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Services.Sales;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Services.Spotify;
using VinilEcommerce.Infrastructure.Data.Query.Queries.GetDisksById;
using VinilEcommerce.Infrastructure.Data.Query.Queries.GetSalesById;

namespace VinilEcommerce.Infrastructure.Data.Query.Tests.Unit.Queries.Mocks.Mappers
{
    public sealed class MapperMock
    {
        public IMapper GetMock()
        {
            var mock = Substitute.For<IMapper>();
            var fixture = new Fixture();

            mock.Map<SpotifyDataBaseResponse, GetDisksByIdCommandResponse>(Arg.Any<SpotifyDataBaseResponse>())
                .Returns(fixture.Create<GetDisksByIdCommandResponse>());

            mock.Map<SalesDataBaseResponse, GetSalesByIdCommandResponse>(Arg.Any<SalesDataBaseResponse>())
                .Returns(fixture.Create<GetSalesByIdCommandResponse>());

            return mock;
        }
    }
}
