using Glaubers.Portifolio.Api.Domain.Enums;

namespace Glaubers.Portifolio.Api.Domain.Models
{
    public class User : BaseModel
    {
        public string Nickname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UserType UserType { get; set; } = UserType.Default;
        public int Age => GetAge();
        public DateTime Birth { get; set; }

        public int GetAge()
        {
            DateTime currentDate = DateTime.Now;

            var respAge = currentDate.Year - Birth.Year;

            if (currentDate.Month < Birth.Month || (currentDate.Month == Birth.Month && currentDate.Day < Birth.Day))
                respAge--;

            return respAge;
        }
    }
}
