using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Services.Model.Entities
{
    [ComplexType]
    public class Address
    {
        [JsonProperty("rua")]
        public string Street { get; set; }
        [JsonProperty("bairro")]
        public string Neighborhood { get; set; }
        [JsonProperty("cidade")]
        public string City { get; set; }
        [JsonProperty("estado")]
        public string State { get; set; }
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }
}
