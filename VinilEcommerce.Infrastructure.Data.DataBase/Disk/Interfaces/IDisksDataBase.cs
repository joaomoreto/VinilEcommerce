using System.Collections.Generic;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Services.Cashback;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Services.Sales;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Services.Spotify;

namespace VinilEcommerce.Infrastructure.Data.DataBase.Disk.Interfaces
{
    public interface IDisksDataBase
    {
        IEnumerable<CashbackDataBaseResponse> GetCashback(string day);

        IEnumerable<SpotifyDataBaseResponse> GetDisksByGenre(SpotifyGenreDataBaseRequest request);

        SpotifyDataBaseResponse GetDisksById(int id);

        IEnumerable<SalesDataBaseResponse> GetSalesByDate(SpotifyDateDataBaseRequest request);

        SalesDataBaseResponse GetSalesById(int id);

        void UpdateTableSpotify(IEnumerable<SpotifyDataBaseRequest> request);

        void SellDisks(IEnumerable<SalesDataBaseRequest> request);
    }
}
