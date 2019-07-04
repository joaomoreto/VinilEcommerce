using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using NUnit.Framework;
using VinilEcommerce.Infrastructure.Data.Query.Queries.GetDisksById;
using VinilEcommerce.Infrastructure.Data.Query.Tests.Unit.Queries.Mocks.Mappers;
using VinilEcommerce.Infrastructure.Data.Query.Tests.Unit.Queries.Mocks.Services;

namespace VinilEcommerce.Infrastructure.Data.Query.Tests.Unit.Queries.GetDisksById
{
    [TestFixture]
    public class GetDisksByIdCommandHandlerTest
    {
        private static GetDisksByIdCommandHandler EstablishContext() => new GetDisksByIdCommandHandler(
            new DisksDataBaseMock().GetMock(),
            new MapperMock().GetMock());

        [Test]
        public async Task GetDisksById()
        {
            var response = await EstablishContext()
                .Handle(new Fixture().Create<GetDisksByIdCommand>(), CancellationToken.None);

            Assert.IsNotNull(response);
        }
    }
}