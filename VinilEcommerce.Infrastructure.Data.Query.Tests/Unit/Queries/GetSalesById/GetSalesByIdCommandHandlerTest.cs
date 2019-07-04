using AutoFixture;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using VinilEcommerce.Infrastructure.Data.Query.Queries.GetSalesById;
using VinilEcommerce.Infrastructure.Data.Query.Tests.Unit.Queries.Mocks.Mappers;
using VinilEcommerce.Infrastructure.Data.Query.Tests.Unit.Queries.Mocks.Services;

namespace VinilEcommerce.Infrastructure.Data.Query.Tests.Unit.Queries.GetSalesById
{
    [TestFixture]
    public class GetSalesByIdCommandHandlerTest
    {
        private static GetSalesByIdCommandHandler EstablishContext() => new GetSalesByIdCommandHandler(
            new DisksDataBaseMock().GetMock(),
            new MapperMock().GetMock());

        [Test]
        public async Task GetSalesById()
        {
            var response = await EstablishContext()
                .Handle(new Fixture().Create<GetSalesByIdCommand>(), CancellationToken.None);

            Assert.IsNotNull(response);
        }
    }
}