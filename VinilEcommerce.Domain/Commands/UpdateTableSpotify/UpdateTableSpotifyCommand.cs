using MediatR;
using System.Collections.Generic;

namespace VinilEcommerce.Domain.Commands.UpdateTableSpotify
{
    public sealed class UpdateTableSpotifyCommand : IRequest
    {
        public IEnumerable<string> Genres { get; set; }
    }
}
