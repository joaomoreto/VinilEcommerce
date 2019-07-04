using System;
using Newtonsoft.Json;

namespace VinilEcommerce.Infrastructure.Data.Query.Queries.GetSalesById
{
    public sealed class GetSalesByIdCommandResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("genre")]
        public string Genre { get; set; }

        [JsonProperty("cashback")]
        public decimal Cashback { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }
}
