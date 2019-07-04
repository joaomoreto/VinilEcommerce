using System.Collections.Generic;
using AutoFixture;
using NSubstitute;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Interfaces;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Services.Cashback;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Services.Sales;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Services.Spotify;

namespace VinilEcommerce.Domain.Tests.Unit.Commands.Mocks.Services
{
    public class DisksDataBaseMock
    {
        public IDisksDataBase GetMock()
        {
            var mock = Substitute.For<IDisksDataBase>();
            var fixture = new Fixture();

            mock.SellDisks(Arg.Any<IEnumerable<SalesDataBaseRequest>>());

            mock.UpdateTableSpotify(Arg.Any<IEnumerable<SpotifyDataBaseRequest>>());

            mock.GetDisksById(Arg.Any<int>())
                .Returns(fixture.Create<SpotifyDataBaseResponse>());

            mock.GetCashback(Arg.Any<string>())
                .Returns(fixture.Create<IEnumerable<CashbackDataBaseResponse>>());

            mock.GetDisksByGenre(Arg.Any<SpotifyGenreDataBaseRequest>())
                .Returns(fixture.Create<IEnumerable<SpotifyDataBaseResponse>>());

            mock.GetSalesById(Arg.Any<int>())
                .Returns(fixture.Create<SalesDataBaseResponse>());

            return mock;
        }
    }

}
