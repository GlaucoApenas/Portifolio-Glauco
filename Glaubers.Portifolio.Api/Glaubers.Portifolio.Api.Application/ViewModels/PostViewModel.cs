using Glaubers.Portifolio.Api.Domain.Models;

namespace Glaubers.Portifolio.Api.Application.ViewModels
{
    public class PostViewModel : BaseViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public Guid UserID { get; set; }
        public virtual User? User { get; set; }
        public Guid CategoryID { get; set; }
        public virtual Category? Category { get; set; }
    }
}
