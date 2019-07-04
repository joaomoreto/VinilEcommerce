using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace VinilEcommerce.Infrastructure.Data.Query.Queries.GetSalesByDate
{
    public sealed class GetSalesByDateCommandResponse
    {
        [JsonProperty("sales")]
        public IEnumerable<Sale> Sales { get; set; }

        public class Sale
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
}
