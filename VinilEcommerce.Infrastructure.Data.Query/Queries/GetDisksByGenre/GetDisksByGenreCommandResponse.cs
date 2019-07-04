using Newtonsoft.Json;
using System.Collections.Generic;

namespace VinilEcommerce.Infrastructure.Data.Query.Queries.GetDisksByGenre
{
    public sealed class GetDisksByGenreCommandResponse
    {
        [JsonProperty("disks")]
        public IEnumerable<Disk> Disks { get; set; }

        public class Disk
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("genre")]
            public string Genre { get; set; }

            [JsonProperty("price")]
            public decimal Price { get; set; }
        }
    }
}
