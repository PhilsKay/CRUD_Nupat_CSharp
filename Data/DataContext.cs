﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nupat_CSharp.Models;

namespace Nupat_CSharp.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>  
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Job> Job { get; set; }
        public DbSet<Languages> Languages { get; set; }
    }
}
