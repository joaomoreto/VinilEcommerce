using AutoFixture;
using NSubstitute;
using Spotify.API.NetCore.Models;
using System.Collections.Generic;
using VinilEcommerce.Infrastructure.Service.Interfaces.Spotify;

namespace VinilEcommerce.Domain.Tests.Unit.Commands.Mocks.Services
{
    public class SpotifyServiceMock
    {
        public ISpotifyServiceHandler GetMock()
        {
            var mock = Substitute.For<ISpotifyServiceHandler>();
            var fixture = new Fixture();

            mock.GetDisksByGenre(Arg.Any<string>())
                .Returns(fixture.Create<IEnumerable<SimpleAlbum>>());

            return mock;
        }
    }

}
