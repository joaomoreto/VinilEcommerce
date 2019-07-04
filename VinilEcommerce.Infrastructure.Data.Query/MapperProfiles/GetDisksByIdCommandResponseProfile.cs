using AutoMapper;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Services.Spotify;
using VinilEcommerce.Infrastructure.Data.Query.Queries.GetDisksById;

namespace VinilEcommerce.Infrastructure.Data.Query.MapperProfiles
{
    public sealed class GetDisksByIdCommandResponseProfile : Profile
    {
        public GetDisksByIdCommandResponseProfile()
        {
            CreateMap<SpotifyDataBaseResponse, GetDisksByIdCommandResponse>(MemberList.None);
        }
    }
}
