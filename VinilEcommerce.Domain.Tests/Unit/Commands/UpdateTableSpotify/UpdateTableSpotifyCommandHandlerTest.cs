using AutoFixture;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using VinilEcommerce.Domain.Commands.UpdateTableSpotify;
using VinilEcommerce.Domain.Tests.Unit.Commands.Mocks.Services;

namespace VinilEcommerce.Domain.Tests.Unit.Commands.UpdateTableSpotify
{
    [TestFixture]
    public class UpdateTableSpotifyCommandHandlerTest
    {
        private static UpdateTableSpotifyCommandHandler EstablishContext() => new UpdateTableSpotifyCommandHandler(
            new DisksDataBaseMock().GetMock(),
            new SpotifyServiceMock().GetMock());

        [Test]
        public async Task UpdateTableSpotify()
        {
            var response = await EstablishContext()
                .Handle(new Fixture().Create<UpdateTableSpotifyCommand>(), CancellationToken.None);

            Assert.AreEqual(response, MediatR.Unit.Value);
        }
    }
}