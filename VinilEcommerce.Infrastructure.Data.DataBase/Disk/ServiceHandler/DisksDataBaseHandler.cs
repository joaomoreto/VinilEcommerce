using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using VinilEcommerce.CrossCutting.Exception;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Interfaces;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Services.Cashback;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Services.Sales;
using VinilEcommerce.Infrastructure.Data.DataBase.Disk.Services.Spotify;

namespace VinilEcommerce.Infrastructure.Data.DataBase.Disk.ServiceHandler
{
    public class DisksDataBaseHandler : IDisksDataBase
    {
        private readonly string _connectionString;

        public DisksDataBaseHandler(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<CashbackDataBaseResponse> GetCashback(string day)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    return connection.Query<CashbackDataBaseResponse>(
                        $"SELECT genre, {day} AS Value FROM cashback " +
                        "ORDER BY Id ASC");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new ConnectionDataBaseFailedException();
            }
        }

        public IEnumerable<SpotifyDataBaseResponse> GetDisksByGenre(SpotifyGenreDataBaseRequest request)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var query = "SELECT * FROM spotify " +
                                $"WHERE genre = '{request.Genre}'" +
                                " ORDER BY name ASC " +
                                $"LIMIT {(request.Page - 1) * request.RecordsNumber},{request.RecordsNumber};";

                    return connection.Query<SpotifyDataBaseResponse>(query);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new ConnectionDataBaseFailedException();
            }
        }

        public SpotifyDataBaseResponse GetDisksById(int id)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    return connection.Query<SpotifyDataBaseResponse>(
                        "SELECT * FROM spotify " +
                        $"WHERE id = {id}").FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new ConnectionDataBaseFailedException();
            }
        }

        public IEnumerable<SalesDataBaseResponse> GetSalesByDate(SpotifyDateDataBaseRequest request)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    var query = "SELECT * FROM sales " +
                                "WHERE date " +
                                $"BETWEEN '{request.StartDate.ToString("yyyy/dd/MM", CultureInfo.InvariantCulture)}' " +
                                $"AND '{request.EndDate.ToString("yyyy/dd/MM", CultureInfo.InvariantCulture)}' " +
                                " ORDER BY date DESC " +
                                $"LIMIT {(request.Page - 1) * request.RecordsNumber},{request.RecordsNumber};";

                    return connection.Query<SalesDataBaseResponse>(query);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new ConnectionDataBaseFailedException();
            }
        }

        public SalesDataBaseResponse GetSalesById(int id)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    return connection.Query<SalesDataBaseResponse>(
                        "SELECT * FROM sales " +
                        $"WHERE id = {id}").FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new ConnectionDataBaseFailedException();
            }
        }

        public void UpdateTableSpotify(IEnumerable<SpotifyDataBaseRequest> request)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Execute(
                        "INSERT INTO spotify (name, genre, price) " +
                        "VALUES(@name, @genre, @price)", request);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new ConnectionDataBaseFailedException();
            }
        }

        public void SellDisks(IEnumerable<SalesDataBaseRequest> request)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Execute(
                        "INSERT INTO sales (id_spotify, name, genre, cashback, date) " +
                        "VALUES(@id, @name, @genre, @cashback, @date)", request);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new ConnectionDataBaseFailedException();
            }
        }
    }
}
