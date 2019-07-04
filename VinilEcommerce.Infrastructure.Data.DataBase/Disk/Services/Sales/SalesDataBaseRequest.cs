using System;

namespace VinilEcommerce.Infrastructure.Data.DataBase.Disk.Services.Sales
{
    public class SalesDataBaseRequest
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public string Genre { get; set; }

        public decimal Cashback { get; set; }

        public DateTime Date { get; set; }
    }
}
