using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Interfaces;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Services.Spotify;
using VinilEcommerce.Infrastructure.Service.Interfaces.Spotify;

namespace VinilEcommerce.Domain.Commands.UpdateTableSpotify
{
    public sealed class UpdateTableSpotifyCommandHandler :
        IRequestHandler<UpdateTableSpotifyCommand>
    {
        private readonly IDisksDataBase _disksDataBase;
        private readonly ISpotifyServiceHandler _spotifyServiceHandler;

        public UpdateTableSpotifyCommandHandler(
            IDisksDataBase disksDataBase,
            ISpotifyServiceHandler spotifyServiceHandler)
        {
            _disksDataBase = disksDataBase;
            _spotifyServiceHandler = spotifyServiceHandler;
        }

        public async Task<Unit> Handle(UpdateTableSpotifyCommand request, CancellationToken cancellationToken)
        {
            foreach (var genre in request.Genres)
            {
                var disksByGenre = _spotifyServiceHandler.GetDisksByGenre(genre.ToLower());
                var requestService = new List<SpotifyDataBaseRequest>();
                var random = new Random();

                foreach (var disk in disksByGenre)
                {
                    requestService.Add(new SpotifyDataBaseRequest
                    {
                        Genre = genre,
                        Name = disk.Name,
                        Price = random.Next(80, 250)
                    });
                }

                _disksDataBase.UpdateTableSpotify(requestService);
            }

            return Unit.Value;
        }
    }
}
