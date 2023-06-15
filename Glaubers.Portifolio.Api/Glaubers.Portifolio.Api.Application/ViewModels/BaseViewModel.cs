using System.Text.Json.Serialization;

namespace Glaubers.Portifolio.Api.Application.ViewModels
{
    public class BaseViewModel
    {
        public Guid ID { get; set; }
        public DateTime Created { get; set; }
        [JsonIgnore]
        public DateTime? LastUpdate { get; set; }
        [JsonIgnore]
        public DateTime? Deleted { get; set; }
    }
}
