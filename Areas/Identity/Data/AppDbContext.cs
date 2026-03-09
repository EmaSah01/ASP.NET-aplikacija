using ASP.NET_aplikacija.DL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ASP.NET_aplikacija.Areas.Identity.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<RatingEntity> Ratings { get; set; }
    }
}
