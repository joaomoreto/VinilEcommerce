using System;
using Spotify.API.NetCore;
using Spotify.API.NetCore.Auth;
using Spotify.API.NetCore.Enums;
using Spotify.API.NetCore.Models;
using System.Collections.Generic;
using System.Linq;
using VinilEcommerce.Infrastructure.Service.Interfaces.Spotify;

namespace VinilEcommerce.Infrastructure.Service.ServiceHandler.Spotify
{
    public class SpotifyServiceHandler : ISpotifyServiceHandler
    {
        private const string ClientId = "c2a8804d97cd4d88baf373b64307bd59";
        private const string ClientSecret = "f8b4cfe6e225483a862eb04a5bf0d3fe";

        private SpotifyWebAPI _spotifyApi;

        public SpotifyServiceHandler()
        {
            var auth = new ClientCredentialsAuth();
            auth.ClientId = ClientId;
            auth.ClientSecret = ClientSecret;

            var token = auth.DoAuth();
            _spotifyApi = new SpotifyWebAPI() { TokenType = token.TokenType, AccessToken = token.AccessToken };
        }

         
        public IEnumerable<SimpleAlbum> GetDisksByGenre(string genre)
        {
            var result = new List<SimpleAlbum>();
            var count = 0;

            do
            {
                var artistsItems = _spotifyApi.SearchItems("a", SearchType.Artist, 50, count * 50);
                var artistsGenre = artistsItems.Artists.Items.Where(x =>
                    x.Genres.Any(y => y.Equals(genre, StringComparison.CurrentCultureIgnoreCase)));

                foreach (var artist in artistsGenre)
                {
                    result.AddRange(_spotifyApi.GetArtistsAlbums(artist.Id, AlbumType.All, 50).Items);
                    result = result.GroupBy(x => x.Name).Select(y => y.First()).ToList();

                    if (result.Count >= 50)
                        return result.GetRange(0,50);
                }

                count++;

            } while (count < 3 && result.Count < 50);

            return result;
        }
    }
}
