using Microsoft.EntityFrameworkCore;
using Nupat_CSharp.Models;

namespace Nupat_CSharp.Data
{
    public class DataContext : DbContext    
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Job> Job { get; set; }
    }
}
