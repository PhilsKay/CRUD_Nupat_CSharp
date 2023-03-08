using System.ComponentModel.DataAnnotations;

namespace Nupat_CSharp.Models
{
    public class Job
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Salary { get; set; }
        public string Qualification { get; set; }
        public string Experience { get; set; }


    }
}
