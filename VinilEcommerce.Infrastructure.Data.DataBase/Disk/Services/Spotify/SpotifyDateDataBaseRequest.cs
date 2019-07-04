using System;

namespace VinilEcommerce.Infrastructure.Data.DataBase.Disk.Services.Spotify
{
    public class SpotifyDateDataBaseRequest
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Page { get; set; }

        public int RecordsNumber { get; set; }
    }
}
