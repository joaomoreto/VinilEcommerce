using AutoFixture;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using VinilEcommerce.Infrastructure.Data.Query.Queries.GetSalesByDate;
using VinilEcommerce.Infrastructure.Data.Query.Tests.Unit.Queries.Mocks.Mappers;
using VinilEcommerce.Infrastructure.Data.Query.Tests.Unit.Queries.Mocks.Services;

namespace VinilEcommerce.Infrastructure.Data.Query.Tests.Unit.Queries.GetSalesByDate
{
    [TestFixture]
    public class GetSalesByDateCommandHandlerTest
    {
        private static GetSalesByDateCommandHandler EstablishContext() => new GetSalesByDateCommandHandler(
            new DisksDataBaseMock().GetMock(),
            new MapperMock().GetMock());

        [Test]
        public async Task GetSalesByDate()
        {
            var response = await EstablishContext()
                .Handle(new Fixture().Create<GetSalesByDateCommand>(), CancellationToken.None);

            Assert.IsNotNull(response);
        }
    }
}