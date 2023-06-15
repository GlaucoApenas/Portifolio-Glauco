using System.Text.Json.Serialization;

namespace Glaubers.Portifolio.Api.Domain.Models
{
    public class BaseModel
    {
        public Guid ID { get; set; }
        public DateTime Created { get; set; }
        [JsonIgnore]
        public DateTime? LastUpdate { get; set; }
        [JsonIgnore]
        public DateTime? Deleted { get; set; }
    }
}
