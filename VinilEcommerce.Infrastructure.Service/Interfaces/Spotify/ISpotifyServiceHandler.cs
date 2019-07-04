using Spotify.API.NetCore.Models;
using System.Collections.Generic;

namespace VinilEcommerce.Infrastructure.Service.Interfaces.Spotify
{
    public interface ISpotifyServiceHandler
    {
        IEnumerable<SimpleAlbum> GetDisksByGenre(string genre);
    }
}
