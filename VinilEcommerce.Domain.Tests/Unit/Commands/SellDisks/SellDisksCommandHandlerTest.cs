using AutoFixture;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using VinilEcommerce.Domain.Commands.SellDisks;
using VinilEcommerce.Domain.Tests.Unit.Commands.Mocks.Services;

namespace VinilEcommerce.Domain.Tests.Unit.Commands.SellDisks
{
    [TestFixture]
    public class SellDisksCommandHandlerTest
    {
        private static SellDisksCommandHandler EstablishContext() => new SellDisksCommandHandler(
            new DisksDataBaseMock().GetMock());

        [Test]
        public async Task SellDisks()
        {
            var response = await EstablishContext()
                .Handle(new Fixture().Create<SellDisksCommand>(), CancellationToken.None);

            Assert.AreEqual(response, MediatR.Unit.Value);
        }
    }
}