using AutoMapper;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Services.Spotify;
using VinilEcommerce.Infrastructure.Data.Query.Queries.GetDisksByGenre;

namespace VinilEcommerce.Infrastructure.Data.Query.MapperProfiles
{
    public sealed class GetDisksByGenreCommandResponseProfile : Profile
    {
        public GetDisksByGenreCommandResponseProfile()
        {
            CreateMap<SpotifyDataBaseResponse, GetDisksByGenreCommandResponse.Disk>(MemberList.None);
        }
    }
}
