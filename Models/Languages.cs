namespace Nupat_CSharp.Models
{
    public class Languages
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
