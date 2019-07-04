using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using NUnit.Framework;
using VinilEcommerce.Infrastructure.Data.Query.Queries.GetDisksByGenre;
using VinilEcommerce.Infrastructure.Data.Query.Tests.Unit.Queries.Mocks.Mappers;
using VinilEcommerce.Infrastructure.Data.Query.Tests.Unit.Queries.Mocks.Services;

namespace VinilEcommerce.Infrastructure.Data.Query.Tests.Unit.Queries.GetDisksByGenre
{
    [TestFixture]
    public class GetDisksByGenreCommandHandlerTest
    {
        private static GetDisksByGenreCommandHandler EstablishContext() => new GetDisksByGenreCommandHandler(
            new DisksDataBaseMock().GetMock(),
            new MapperMock().GetMock());

        [Test]
        public async Task GetDisksByGenre()
        {
            var response = await EstablishContext()
                .Handle(new Fixture().Create<GetDisksByGenreCommand>(), CancellationToken.None);

            Assert.IsNotNull(response);
        }
    }
}