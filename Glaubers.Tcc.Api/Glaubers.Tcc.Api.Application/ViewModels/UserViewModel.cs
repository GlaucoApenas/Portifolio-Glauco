using Glaubers.Tcc.Api.Domain.Enums;
using Newtonsoft.Json;

namespace Glaubers.Tcc.Api.Application.ViewModels
{
    public class UserViewModel
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public bool Enabled { get; set; } = true;
        public DateTime Birth { get; set; }
        public UserType UserType { get; set; } = UserType.Default;
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
