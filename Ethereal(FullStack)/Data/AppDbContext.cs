using Ethereal_FullStack_.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ethereal_FullStack_.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Setting> Settings { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<CustomUser> CustomUsers { get; set; }
    }
}
