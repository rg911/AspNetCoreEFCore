using GulpDemo.Dal.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using Microsoft.Extensions.Configuration;

namespace GulpDemo.Dal
{
    public class GulpDemoContext :IdentityDbContext<ApplicationUser>
    {
        private IConfigurationRoot config;
        public GulpDemoContext(IConfigurationRoot config, DbContextOptions options):base(options)
        {
            this.config = config;
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(config["ConnectionStrings:GulpDemoContextConnection"]);
        }
    }
}
