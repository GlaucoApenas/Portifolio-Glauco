using Glaubers.Tcc.Api.Domain.Enums;

namespace Glaubers.Tcc.Api.Domain.Models
{
    public class User
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public bool Enabled { get; set; } = true;
        public DateTime Birth { get; set; }
        public DateTime Created { get; set; }
        public UserType UserType { get; set; }
    }
}
