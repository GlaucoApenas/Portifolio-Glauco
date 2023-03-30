using System.ComponentModel.DataAnnotations;

namespace Glaubers.Tcc.Api.Domain.Enums
{
    public enum UserType
    {
        [Display(Name = "Student")]
        Student,
        [Display(Name = "Teacher")]
        Teacher,
        [Display(Name = "Coordinator")]
        Coordinator,
        [Display(Name = "Administrator")]
        Administrator = 10000,
        [Display(Name = "Default")]
        Default = 0,
    }
}
