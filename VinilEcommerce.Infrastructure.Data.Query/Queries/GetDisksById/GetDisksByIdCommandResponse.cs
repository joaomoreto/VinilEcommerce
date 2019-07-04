using Newtonsoft.Json;

namespace VinilEcommerce.Infrastructure.Data.Query.Queries.GetDisksById
{
    public sealed class GetDisksByIdCommandResponse
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
