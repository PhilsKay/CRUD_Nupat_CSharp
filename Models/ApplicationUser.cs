using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Nupat_CSharp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        [MaxLength(150, ErrorMessage = "Age must be below 150")]
        [MinLength(18,ErrorMessage ="Age must be greater than 18")]
        public int Age { get; set; }
    }
}
