using System.ComponentModel.DataAnnotations;

namespace Nupat_CSharp.ViewModel
{
    public class JobViewModel
    {

        [Required]
        public string Title { get; set; }

        [Required]

        public string Salary { get; set; }
        [Required]

        public string Qualification { get; set; }
        [Required]

        public string Experience { get; set; }
    }
}
